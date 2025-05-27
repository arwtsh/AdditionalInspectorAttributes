# Documentation

## Overview

A Unity package that adds attributes which hides a property from the inspector if a conditional is met.

## Package contents

- 8 Attributes

## Installation Instructions

Installing this package via the Unity package manager is the best way to install this package. There are multiple methods to install a third-party package using the package manager, the recommended one is `Install package from Git URL`. The URL for this package is `https://github.com/arwtsh/ConditionalHideInInspectorAttributes.git`. The Unity docs contains a walkthrough on how to install a package. It also contains information on [specifying a specific branch or release](https://docs.unity3d.com/6000.0/Documentation/Manual/upm-git.html#revision).

Alternatively, you can download directly from this GitHub repo and extract the .zip file into the folder `ProjectRoot/Packages/com.jjasundry.conditional-hide-in-inspector`. This will also allow you to edit the contents of the package.

## Requirements

Tested on Unity version 6000.0; will most likely work on older versions, but you will need to manually port it.

## Description of Assets

This package adds 3 types of attributes which dynamically hide a serialized property from the inspector (similiar to [HideInInspector](https://docs.unity3d.com/ScriptReference/HideInInspector.html)) based on another value. These types are:
- Boolean
  - ShowInInspectorIfTrue
  - ShowInInspectorIfFalse
  - HideInInspectorIfTrue
  - HideInInspectorIfFalse
- Null check
  - ShowInInspectorIfNull
  - ShowInInspectorIfNotNull
  - HideInInspectorIfNull
  - HideInInspectorIfNotNull
- Equality
  - ShowInInspectorIfEqual
  - ShowInInspectorIfNotEqual
  - HideInInspectorIfEqual
  - HideInInspectorIfNotEqual

Because of the limitations of C#, the name of the variable or method must be used as the parameter. I'm sorry.
