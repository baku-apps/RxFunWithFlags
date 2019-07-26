# Reactive Extensions Fun With Flags Demo

Code used to demo the power of Rx by comparing the readability of code when writing a very simple app. [Presentation](https://www.slideshare.net/secret/LPYpXwBnk9lbz6)

**App requirements:**

 1. Delay search request after each keystroke for 0.5 seconds. 
 2. Handle delayed search requests. 
 3. Discard previous search request and only show latest results. 
 4. Only search request after search term > 1 characters. 
 5. Only perform search request until search term is changed
 6. Have a 30 seconds timeout for the server response.

**Code example comparing C# TPL vs Rx**
![C# TPL vs Rx.NET code](https://github.com/baku-apps/RxFunWithFlags/blob/master/TPL-vs-Rx.png)
