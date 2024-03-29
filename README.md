# InspireTale Utils
Unity pakcage which contain useful stuff. Written by Sahapat tong-on.

## Table Content

- [TextAdjusters](#text-adjusters)
- [Singletons](#singletons)
- [Scene Transition](#scene-transition)
- [Utility](#utility)

## How to install

1. Dowload Unity package from this github. There is on github releases or click this [link](https://github.com/Sahapat/InspireTaleUnityFramework/releases)
2. Import into Unity package by. <br>
2.1 Click on **Assets** >> **Import Package** >> **Custom Package** <br>
2.2 Then Select InspireTale Utils package to import.

3. Before using, Import InspierTaleFramework into your script <br>
    ```csharp
    using InspireTale.Utils;
    ```

<b>Example</b>

## Singletons

Singleton is a pattern that fix the class to have only single instance. This pattern is useful for a controller or manager that can access and have single state when call from other object without sending argument. <br>

**NOTE**: This is secure by singleton guideline because it is not a pure singleton object, it has no concept of hiding contructor to prevent create an object, it just a wrapper that provide singleton instance.

You can convert you object into singleton pattern by these utilities.

### Singleton
This class is for a regular class. It will convert your class into singleton by inherite **Singleton** class and set generic type as your class.

```csharp
//  Let suppose that we have MyClass as a regular class
//  then we want that to be a singleton
//  You have to inherit Singleton and set generic as <MyClass>
class MyClass : Singleton<MyClass>
{
}

//  Now your class will be a singleton object that can access by Instance
MyClass.Instance
```

### MonoSingleton
In Unity, an object must inherite MonoBehavior to get event hook and other stuff. Thus i have to create MonoSingleton that use for Unity object only. MonoSingleton is a class that will be set an object into *DontDestroyOnLoad* scene. This class is lock for only Unity Object that can be inherit.

```csharp
//  Let suppose that we have Bullet as Unity object class
//  then we want that to be a singleton
//  Tou have to inherit MonoSingleton and set generic as <Bullet>
class Bullet : MonoSingleton<Bullet>
{

}

//  Now your class will be a singleton object that can access by Instance
Bullet.Instance
```
## Scene Transition

Transition will be in prefab canvas, There are in **InspireTaleFramework** > **Prefabs** directory. For using, Drag the prefab into your scene and control via Instance of transition controller.

### Fading

Fading is transition that will change alpha of the cover image. You can change transition color by change image overlay color. The transition controller is SceneFadingTransition script. <br>

Fading transition provide singleton instance to easier using. Thus you can access by

```csharp
SceneFadingTransition.Instance //   This will be an instance of Unity gameobject.
```

Then there are asynchronous function for animating fading alpha. <br>

```csharp
FadeImageAlphaTask (float startValue, float endValue, float time_s)

//  startValue - initialize value that will be set before fade
//  endValue - final value that will be fade to.
//  time_s - time to fade to end value in seconds.

//  return - Task (asynchronous)

```

Example

```csharp
SceneFadingTransition.Instance.FadeImageAlphaTask(0, 1, 1f)
//   This will be fading alpha from 0 to 1 in 1 seconds
```

## Utility

### CompareUtil

```csharp
CompareFloat(float value1, float value2)
//  value1 - first value to compare
//  value2 - second value to compare

//  return boolean to comparsion
```

### RandomUtil

```csharp
RandomByPercentage(float percentage)
//  percentage - percentage that will get true from this function

//  return boolean
//      true if the random is match
//      false if the random is not match
```

### ScreenUtil

Available property <br>
- ScreenWidth : int
- ScreenHeight : int

In Screen2D
- LeftScreenEdgePosition : float
- RightScreenEdgePosition : float
- TopScreenEdgePosition : float
- BottomScreenEdgePosition : float
- ScreenEdgePostion : Vector4
