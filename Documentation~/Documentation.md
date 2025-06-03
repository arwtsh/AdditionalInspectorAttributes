# Documentation

## Overview

A Unity package that adds attributes which hides a property from the inspector if a conditional is met.

## Package contents

- 8 Attributes

## Installation Instructions

Installing this package via the Unity package manager is the best way to install this package. There are multiple methods to install a third-party package using the package manager, the recommended one is `Install package from Git URL`. The URL for this package is `https://github.com/arwtsh/AdditionalInspectorAttributes.git`. The Unity docs contains a walkthrough on how to install a package. It also contains information on [specifying a specific branch or release](https://docs.unity3d.com/6000.0/Documentation/Manual/upm-git.html#revision).

Alternatively, you can download directly from this GitHub repo and extract the .zip file into the folder `ProjectRoot/Packages/com.jjasundry.additional-inspector-attributes`. This will also allow you to edit the contents of the package.

## Requirements

Tested on Unity version 6000.0; will most likely work on older versions, but you will need to manually port it.

## Description of Assets

This package adds new attributes which modify how serialized properties behave in the inspector (such as [HideInInspector](https://docs.unity3d.com/ScriptReference/HideInInspector.html)). These types are:
- **Read Only** - Makes this property not editable in the inspector, but will still display its value.
- **Conditional HideInInspector**
  - **Boolean** - Either hides or shows the property based on a boolean property, field, or method's return value.
    - ShowInInspectorIfTrue
    - ShowInInspectorIfFalse
    - HideInInspectorIfTrue
    - HideInInspectorIfFalse
  - **Null check** - Either hides or shows the property if a property, field, or method's return value is null.
    - ShowInInspectorIfNull
    - ShowInInspectorIfNotNull
    - HideInInspectorIfNull
    - HideInInspectorIfNotNull
  - **Equality** - Either hides or shows the property if a property, field, or method's return value is equal to a predefined value.
    - ShowInInspectorIfEqual
    - ShowInInspectorIfNotEqual
    - HideInInspectorIfEqual
    - HideInInspectorIfNotEqual
  - **Editor Mode** - Either hides or shows the property if the editor is in play mode.
    - ShowInInspectorWhilePlaying
    - ShowInInspectorWhileEditing
    - HideInInspectorWhilePlaying
    - HideInInspectorWhileEditing
- **Conditional ReadOnly**
  - **Boolean** - Property is readonly based on a boolean property, field, or method's return value.
    - EnableInInspectorIfTrue
    - EnableInInspectorIfFalse
    - DisableInInspectorIfTrue
    - DisableInInspectorIfFalse
  - **Null check** - Property is readonly if a property, field, or method's return value is null.
    - EnableInInspectorIfNull
    - EnableInInspectorIfNotNull
    - DisableInInspectorIfNull
    - DisableInInspectorIfNotNull
  - **Equality** - Property is readonly if a property, field, or method's return value is equal to a predefined value.
    - EnableInInspectorIfEqual
    - EnableInInspectorIfNotEqual
    - DisableInInspectorIfEqual
    - DisableInInspectorIfNotEqual
  - **Editor Mode** - Property is readonly if the editor is in play mode.
    - EnableInInspectorWhilePlaying
    - EnableInInspectorWhileEditing
    - DisableInInspectorWhilePlaying
    - DisableInInspectorWhileEditing

Because of the limitations of C#, names of variables must be used to reference non-constants in attributes. I'm sorry. There is this helpful expression called [nameof()](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/nameof) which will make the syntax less painful.
