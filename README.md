# Application <insert name>

## Purpose
Sort user input and store local i.e., 3,2,1 -> 1,2,3. The sorted input is stored in a local .csv. 
Two endpoints are exposed: local/get and local/post. /post allows the user to input a comma-seperated input,
which is then being sorted, while /get returns all the sorted inputs. 

### Done
- 2 endpoints
- bubble-sort

### Missing
- A better sorting algorithm
- decouple
    - Swap .csv with a database
    - Unit testing 

### Bugs
- /get is concatenated into 1 list
