"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild" Sygic.Maps.Clients.csproj /t:Rebuild /p:Configuration=Release /m /clp:ErrorsOnly
NuGet.exe pack Sygic.Maps.Clients.csproj -Prop Configuration=Release