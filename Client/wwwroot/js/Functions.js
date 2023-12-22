//Lien pour le mapping Js/C# : https://sciencevikinglabs.com/blog/development/2021-01-02-blazor-code-snippet-highlightjs/

window.HighlightFunctions = {
    highlightSnippets: function () {
        document.querySelectorAll('pre code').forEach((el) => {
            hljs.highlightBlock(el);
        });
    }
}

//Ajoute un event listner qui fait que quandf on appui sur TAb dans l'interpreteur python, on ajoute une tabulation dans le code a la palce de changer le focus
//Code trouvé sur StackOverflow
window.TabulationFunction = {
    tab: function (id) {
        const element = document.getElementById(id);

        if (element.getAttribute('listener') !== 'true') {
            element.addEventListener('keydown', function (e) {
                if (e.key == 'Tab') {
                    e.preventDefault();
                    var start = this.selectionStart;
                    var end = this.selectionEnd;

                    // set textarea value to: text before caret + tab + text after caret
                    this.value = this.value.substring(0, start) +
                        "\t" + this.value.substring(end);

                    // put caret at right position again
                    this.selectionStart =
                        this.selectionEnd = start + 1;
                }
            });
        }
    }
}

window.PromptFunction = {
    promptFunc: function () {
        return prompt("Nommez votre fichier");
    }
}