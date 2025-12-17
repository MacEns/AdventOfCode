# Input File Loader Component

## Overview
This component provides a cascading `InputFileLoader` service to all pages, allowing each page to load its own unique text file from the `wwwroot` folder.

## Components Created

### 1. InputFileLoader Service (`Services/InputFileLoader.cs`)
A service that loads text files from the `wwwroot` folder and returns them as a `List<string>`.

### 2. InputProvider Component (`Components/InputProvider.razor`)
A wrapper component that:
- Cascades the `InputFileLoader` service to all child components
- Allows each page to load its own unique input file

## How to Use

### In Your Pages
Each page receives the `InputFileLoader` as a cascading parameter and loads its own file in `OnInitializedAsync`:

```razor
@code {
    [CascadingParameter]
    public Services.InputFileLoader InputFileLoader { get; set; } = default!;
    
    private List<string> InputLines { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        InputLines = await InputFileLoader.LoadInputAsync("1.txt");
    }
}
```

### File Naming Convention
Each day page loads its corresponding numbered file:
- Day1.razor loads `1.txt`
- Day2.razor loads `2.txt`
- Day3.razor loads `3.txt`
- ... and so on through Day25.razor loading `25.txt`

### Adding Input Files
Place your text files in the `wwwroot` folder (e.g., `wwwroot/1.txt`, `wwwroot/2.txt`, etc.)

## Example Usage
All day pages (Day1.razor through Day25.razor) have been configured to load their respective input files.

## Setup
The service is registered in `Program.cs`:
```csharp
builder.Services.AddScoped<InputFileLoader>();
```

The cascading value provider is set up in `Components/Routes.razor` to wrap all routed pages.

## Benefits of This Approach
- **Flexibility**: Each page can load a different file based on its day number
- **Performance**: Files are only loaded when the page is accessed
- **Maintainability**: Adding new days is straightforward - just add the cascading parameter and specify the file name


