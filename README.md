# Toycloud.AspNetCore.Mvc.ModelBinding.BodyOrDefaultBinding
Toycloud.AspNetCore.Mvc.ModelBinding.BodyOrDefaultBinding

![.NET Core](https://github.com/shamork/Toycloud.AspNetCore.Mvc.ModelBinding.BodyOrDefaultBinding/workflows/.NET%20Core/badge.svg?branch=master) ![](https://img.shields.io/badge/license-MIT-green.svg)

# Sample

```powershell
Install-Package Toycloud.AspNetCore.Mvc.ModelBinding.BodyOrDefaultBinding
```

## Configuration
```csharp
services.AddMvc(options =>
     {
         options.ModelBinderProviders.InsertBodyOrDefaultBinding();
     })
```

## Enable For One Parameter

```csharp
[HttpPost]
public int SaveData([FromBodyOrDefault]DataPoco m)
{
    ;//
}
```
