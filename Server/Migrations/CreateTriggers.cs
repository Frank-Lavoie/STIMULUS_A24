using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STIMULUS_V2.Server.Migrations
{
    public class CreateTriggers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        CREATE TRIGGER TRG_UpdateStatus
        ON Noeud
        AFTER UPDATE
        AS
        BEGIN
            -- Mettre à jour le statut dans la table Noeud_Etudiant
            UPDATE ne
            SET ne.Status = n.Status
            FROM Noeud_Etudiant ne
            INNER JOIN inserted i ON ne.NoeudId = i.NoeudId 
            INNER JOIN deleted d ON ne.NoeudId = d.NoeudId 
            INNER JOIN Noeud n ON ne.NoeudId = n.NoeudId
            WHERE i.Status <> d.Status OR (i.Status IS NULL AND d.Status IS NOT NULL) OR (i.Status IS NOT NULL AND d.Status IS NULL);
        END;

        CREATE TRIGGER TRG_AfterInsertNoeud
        ON Noeud
        AFTER INSERT
        AS
        BEGIN
            -- Insertion des étudiants dans Noeud_Etudiant
            INSERT INTO Noeud_Etudiant (NoeudId, CodeDA, Status)
            SELECT i.NoeudId, ge.CodeDA, i.Status
            FROM inserted i
            JOIN Graphe g ON i.GrapheId = g.GrapheId
            JOIN Groupe_Etudiant ge ON g.GroupeId = ge.GroupeId;
        END;
    ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        DROP TRIGGER TRG_UpdateStatus;
        DROP TRIGGER TRG_AfterInsertNoeud;
    ");
        }
    }
}
