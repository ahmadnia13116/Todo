// customInterop.js
window.confirmInputWithPrompt = function () {
    let name = prompt("Please enter your name:");

    // Check if the user entered anything or clicked Cancel
    if (name === null || name === "") {
        return null; // Return null to indicate cancellation or no input
    }

    let isConfirmed = confirm("Is your name: " + name + "? Click OK to confirm.");

    if (isConfirmed) {
        return name; // Return the name if confirmed
    } else {
        return null; // Return null if not confirmed
    }
};


window.blazorInterop = {
    // Function to show a prompt and return the input string
    showPrompt: function (message) {
        return prompt(message, "");
    }
};