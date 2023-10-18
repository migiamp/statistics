const queue = [];

        function updateQueueDisplay() {
            const queueList = document.getElementById("queueList");
            queueList.innerHTML = ""; // Clear the list

            for (const element of queue) {
                const listItem = document.createElement("li");
                listItem.textContent = element;
                queueList.appendChild(listItem);
            }
        }

        function enqueue() {
            const elementInput = document.getElementById("elementInput");
            const element = elementInput.value;
            if (element !== "") {
                queue.push(element);
                elementInput.value = ""; // Clear the input field
                updateQueueDisplay();
            }
        }

        function dequeue() {
            if (queue.length > 0) {
                queue.shift(); // Remove the first element
                updateQueueDisplay();
            }
        }

        function search() {
            const searchInput = document.getElementById("searchInput");
            const targetElement = searchInput.value;
            const found = queue.includes(targetElement);
            const result = document.getElementById("resultQueue");
            if (found) {
                result.textContent = `${targetElement} found in the queue.`;
            } else {
                result.textContent = `${targetElement} not found in the queue.`;
            }
            searchInput.value = ""; // Clear the input field
        }