# Toycloud.AspNetCore.Mvc.ModelBinding.BodyAndFormBinding
Toycloud.AspNetCore.Mvc.ModelBinding.BodyAndFormBinding

![.NET Core](https://github.com/shamork/Toycloud.AspNetCore.Mvc.ModelBinding.BodyAndFormBinding/workflows/.NET%20Core/badge.svg?branch=master) ![](https://img.shields.io/badge/license-MIT-green.svg)

# Sample

```powershell
Install-Package Toycloud.AspNetCore.Mvc.ModelBinding.BodyAndFormBinding
```

## Enable globally
```csharp
services.AddMvc(options =>
     {
         options.ModelBinderProviders.InsertBodyAndFormBinding();
     })
```

## Enable For One Parameter

```csharp
[HttpPost]
public int SaveData([FromBodyAndForm]DataPoco m)
{
    ;//
}
```
