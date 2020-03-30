# Toycloud.AspNetCore.Mvc.ModelBinding.BodyOrDefaultBinding
Toycloud.AspNetCore.Mvc.ModelBinding.BodyOrDefaultBinding

![.NET Core](https://github.com/shamork/Toycloud.AspNetCore.Mvc.ModelBinding.BodyOrDefaultBinding/workflows/.NET%20Core/badge.svg?branch=master) ![](https://img.shields.io/badge/license-MIT-green.svg)

# Usage

```powershell
Install-Package Toycloud.AspNetCore.Mvc.ModelBinding.BodyOrDefaultBinding
```

## 1. Configuration
```csharp
services.AddMvc(options =>
     {
         options.ModelBinderProviders.InsertBodyOrDefaultBinding();
     })
```

## 2. Enable For One Parameter

```csharp
[HttpPost]
public int SaveData([FromBodyOrDefault]DataPoco m)
{
    ;//
}
```

# Thanks 

Thank Matiszak

Write this according to Matiszak's Answer
https://stackoverflow.com/questions/45495432/asp-net-core-mvc-mixed-route-frombody-model-binding-validation/45496917

# License

MIT
