build-dotnet-lib:
   cd DotNetLib/DotNetLib && dotnet dotnet publish -c Release -p:UseAppHost=false -o ../../Managed DotNetLib.csproj