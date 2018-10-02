# How to run the Gilded Rose

1. Ensure that you have the latest [.NET Core 2.1 development environment](https://www.microsoft.com/net/download/thank-you/dotnet-sdk-2.1.403-windows-x64-installer) installed on your machine
2. Clone the repository to your local machine
3. Open a command prompt in the newly cloned repository
4. In the root of the repository execute the following command: `dotnet test -c Release .\test\GildedRose.Tests\GildedRose.Tests.csproj`

This will cause the release version of the gilded rose to be built, and all 44 tests to be executed.

5. In the root of the repository execute the following command: `dotnet .\src\GildedRose\bin\Release\netcoreapp2.1\GildedRose.dll`

This will show the initial inventory of the Gilded Rose, age it by one day, and show the new inventory information.