let dictionary = {};

        function createDictionary() {
            const length = parseInt(document.getElementById("length").value, 10);
            dictionary = {};

            for (let i = 0; i < length; i++) {
                const key = getRandomString();
                const value = getRandomString();
                dictionary[key] = value;
            }

            displayDictionary();
        }

        function getRandomString() {
            const chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
            let result = '';
            const length = 5;
            for (let i = 0; i < length; i++) {
                result += chars.charAt(Math.floor(Math.random() * chars.length));
            }
            return result;
        }

        function displayDictionary() {
            const dictionaryElement = document.getElementById("dictionary");
            dictionaryElement.innerHTML = '';
            for (const key in dictionary) {
                const listItem = document.createElement('li');
                listItem.textContent = `${key}: ${dictionary[key]}`;
                dictionaryElement.appendChild(listItem);
            }
        }

        function performOperation() {
            const operation = document.getElementById("operation").value;
            const element = document.getElementById("element").value;
            const resultElement = document.getElementById("resultDictionary");

            switch (operation) {
                case 'add':
                    const key = getRandomString();
                    dictionary[key] = element;
                    displayDictionary();
                    resultElement.textContent = `Added: ${key}: ${element}`;
                    
                    break;
                case 'delete':
                    if (dictionary[element]) {
                        delete dictionary[element];
                        displayDictionary();
                        resultElement.textContent = `Deleted: ${element}`;
                    } else {
                        resultElement.textContent = `Element not found: ${element}`;
                    }
                    break;
                case 'search':
                    if (dictionary[element]) {
                        resultElement.textContent = `Found: ${element}: ${dictionary[element]}`;
                    } else {
                        resultElement.textContent = `Element not found: ${element}`;
                    }
                    break;
            }
        }