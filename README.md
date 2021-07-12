# Server-UI-Enhanced

This sample repository explores a few ways that knockout can be used after the server has rendered pages


# Requirements

- .NET 5.0+
- Visual Studio Code (optional) with the C# extension installed
- Visual Studio 2019 (optional)


# Run

```
dotnet run
```

<kbd>F5</kbd> in visual studio/vscode


# Reference files

- _Layout.cshtml
- wwwroot/js/site.js
- Pages/Posts.cshtml
- Pages/PostDetail.cshtml


The main points to check in your knockout code when looking for performance are

- Reduce the amount of Observables you are using, if a property won't change don't use an observable for it
- Reduce the code inside your computed functions, they are executed constantly to  calculate values, so if the code there is complex it will affect your computed property performance
- Render all you can from the server, try to get most of the important things rendered from the server. If there are lesser important things you can delay the fetch/render of those once your UI is rendered with the important bits
- Use knockout components where possible with parameters rendered from the server this will allou you to "enhance" a part of your UI section by rendering in the server and letting the UI take control once it is rendered.
- If you can't render everything from the server and you must use the UI to do it, try to fetch information in batches although this may require newer browsers since it's easier to do with Javascript [Generators](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Generator) there's an example [here](https://replit.com/@AngelMunoz/Generadorsin#index.js)