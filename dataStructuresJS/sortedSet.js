let sortedSet = [];

        function updateOutput(message) {
            const outputDiv = document.getElementById("outputSortedSet");
            outputDiv.textContent = message;
        }

        function displaySortedSet() {
            updateOutput("Sorted Set: " + sortedSet.join(", "));
        }

        function addElementSortedSet() {
            const inputElement = document.getElementById("sortedSetInput");
            const elementToAdd = inputElement.value.trim();
            if (!elementToAdd || isNaN(elementToAdd)) {
                updateOutput("Invalid input. Please enter a number to add.");
                return;
            }

            const numToAdd = parseFloat(elementToAdd);
            sortedSet.push(numToAdd);
            sortedSet.sort((a, b) => a - b);
            displaySortedSet();
        }

        function deleteElementSortedSet() {
            const inputElement = document.getElementById("sortedSetInput");
            const elementToDelete = inputElement.value.trim();
            if (!elementToDelete || isNaN(elementToDelete)) {
                updateOutput("Invalid input. Please enter a number to delete.");
                return;
            }

            const numToDelete = parseFloat(elementToDelete);
            const index = sortedSet.indexOf(numToDelete);

            if (index !== -1) {
                sortedSet.splice(index, 1);
                displaySortedSet();
            } else {
                updateOutput("Element not found in the sorted set.");
            }
        }

        function searchElementSortedSet() {
            const inputElement = document.getElementById("sortedSetInput");
            const elementToSearch = inputElement.value.trim();
            if (!elementToSearch || isNaN(elementToSearch)) {
                updateOutput("Invalid input. Please enter a number to search.");
                return;
            }

            const numToSearch = parseFloat(elementToSearch);
            const index = sortedSet.indexOf(numToSearch);

            if (index !== -1) {
                updateOutput("Element found at index " + index);
            } else {
                updateOutput("Element not found in the sorted set.");
            }
        }