let stack = [];
        
        function updateStackDisplay() {
            document.getElementById('stack-display').textContent = 'Stack: ' + stack.join(', ');
        }

        function pushElement() {
            const input = document.getElementById('stack-input').value;
            if (input.trim() !== "") {
                stack.push(input);
                updateStackDisplay();
                document.getElementById('stack-input').value = '';
            }
        }

        function popElement() {
            if (stack.length > 0) {
                stack.pop();
                updateStackDisplay();
            }
        }

        function searchElementStack() {
            const searchTerm = document.getElementById('search-input').value;
            if (searchTerm.trim() !== "") {
                const foundIndex = stack.findIndex(item => item === searchTerm);
                if (foundIndex !== -1) {
                    document.getElementById('search-result').textContent = `Element found at position ${foundIndex}`;
                } else {
                    document.getElementById('search-result').textContent = `Element not found in the stack`;
                }
            }
        }