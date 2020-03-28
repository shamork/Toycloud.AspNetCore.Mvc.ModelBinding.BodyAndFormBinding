# Toycloud.AspNetCore.Mvc.ModelBinding.BodyAndFormBinding
Toycloud.AspNetCore.Mvc.ModelBinding.BodyAndFormBinding

![.NET Core](https://github.com/shamork/Toycloud.AspNetCore.Mvc.ModelBinding.BodyAndFormBinding/workflows/.NET%20Core/badge.svg?branch=master)

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
