# Toycloud.AspNetCore.Mvc.ModelBinding.BodyAndFormBinding
Toycloud.AspNetCore.Mvc.ModelBinding.BodyAndFormBinding

![.NET Core](https://github.com/shamork/Toycloud.AspNetCore.Mvc.ModelBinding.BodyAndFormBinding/workflows/.NET%20Core/badge.svg?branch=master) ![](https://img.shields.io/badge/license-MIT-green.svg)

# Sample

```powershell
Install-Package Toycloud.AspNetCore.Mvc.ModelBinding.BodyAndFormBinding -Version 1.0.1
```

```csharp
services.AddMvc(options =>
     {
         options.ModelBinderProviders.InsertBodyAndFormBinding();
     })
```
