# Easing

Simple Unity Easing

## Table of contents
1. [Easing functions](#easing-functions)
2. [Ease](#ease)
2. [Ease3](#ease3)
2. [Ease4](#ease4)
2. [Example usage](#example-usagex)

### Easing functions
Easing functions provide a convenient way to interpolate values smoothly over time. These functions define how the intermediate values between a start and an end point are calculated based on a time factor.

The following easing functions are available for various animation effects:

```csharp
public enum EaseType
{
    Linear,
    SineIn, SineOut, SineInOut,
    QuadIn, QuadOut, QuadInOut,
    CubicIn, CubicOut, CubicInOut,
    QuartIn, QuartOut, QuartInOut,
    QuintIn, QuintOut, QuintInOut,
    ExpoIn, ExpoOut, ExpoInOut,
    CircIn, CircOut, CircInOut,
    BackIn, BackOut, BackInOut,
    ElasticIn, ElasticOut, ElasticInOut,
    BounceIn, BounceOut, BounceInOut,
    Spring
}
```

Easing functions are provided as static methods in the `Ease`, `Ease3` and `Ease4` classes. To use an easing function, simply call the corresponding method and provide the required parameters:

```csharp
using Easing;

float startValue = 0.0f;
float endValue = 1.0f;
float time = 0.5f; // Progress of the interpolation, usually between 0 and 1

float interpolatedValue = Ease.QuadInOut(startValue, endValue, time);

```

### Ease

The `Ease` class provides a collection of easing functions and utility methods for creating smooth animations in Unity. Ease either a float, or the alpha value of UI components.

#### Ease.Go
Initiates a coroutine-based animation with specified parameters.

```csharp
IEnumerator Go(MonoBehaviour m, float from, float to, float time,
    Action<float> update, Action complete = null, EaseType type = EaseType.Linear,
    float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
```

#### Ease.GoAlpha
Initiates an alpha animation with specified parameters.

```csharp
IEnumerator GoAlpha(MonoBehaviour m, float from, float to, float time,
    Action<float> update, Action complete = null, EaseType type = EaseType.Linear,
    float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
```

#### Ease.GoAlphaTo
Initiates an alpha animation to the specified value.

```csharp
IEnumerator GoAlphaTo(MonoBehaviour m, float to, float time,
    Action<float> update = null, Action complete = null, EaseType type = EaseType.Linear,
    float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
```

#### Ease.GoAlphaBy
Initiates an alpha animation by the specified value.

```csharp
IEnumerator GoAlphaBy(MonoBehaviour m, float by, float time,
    Action<float> update = null, Action complete = null, EaseType type = EaseType.Linear,
    float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
```

### Ease3
The `Ease3` class provides static methods for performing easing animations on Vector3 or transform

#### Ease3.Go
Starts an easing animation on a `Vector3` property from a starting value to an ending value.

```csharp
IEnumerator Go(MonoBehaviour m, Vector3 from, Vector3 to, float time,
    Action<Vector3> update, Action complete = null, EaseType type = EaseType.Linear,
    float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
```

#### Ease3.GoPosition
Starts an easing animation on the local position from a starting value to an ending value.

```csharp
IEnumerator GoPosition(MonoBehaviour m, Vector3 from, Vector3 to, float time,
    Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear,
    float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
```

#### Ease3.GoPositionTo
Starts an easing animation on the local position of a Unity object to a specific value.

```csharp
IEnumerator GoPositionTo(MonoBehaviour m, Vector3 to, float time,
    Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear,
    float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
```

#### Ease3.GoPositionBy
Starts an easing animation on the local position of a Unity object by a specific value.
```csharp
IEnumerator GoPositionBy(MonoBehaviour m, Vector3 by, float time,
    Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear,
    float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
```

#### Ease3.GoRotation
Starts an easing animation on the local rotation of a Unity object from a starting value to an ending value.

```csharp
IEnumerator GoRotation(MonoBehaviour m, Vector3 from, Vector3 to, float time,
    Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear,
    float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
```

#### Ease3.GoRotationTo
Starts an easing animation on the local rotation of a Unity object to a specific value.
```csharp
IEnumerator GoRotationTo(MonoBehaviour m, Vector3 to, float time,
    Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear,
    float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
```
#### Ease3.GoRotationBy
Starts an easing animation on the local rotation of a Unity object by a specific value.

```csharp
IEnumerator GoRotationBy(MonoBehaviour m, Vector3 by, float time,
    Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear,
    float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
```

#### Ease3.GoScale
Starts an easing animation on the local scale of a Unity object from a starting value to an ending value.

```csharp
IEnumerator GoScale(MonoBehaviour m, Vector3 from, Vector3 to, float time,
    Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear,
    float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
```

#### Ease3.GoScaleTo
Starts an easing animation on the local scale of a Unity object to a specific value.

```csharp
IEnumerator GoScaleTo(MonoBehaviour m, Vector3 to, float time,
    Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear,
    float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
```
#### Ease3.GoScaleBy
Starts an easing animation on the local scale of a Unity object by a specific value.

```csharp
IEnumerator GoScaleBy(MonoBehaviour m, Vector3 by, float time,
    Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear,
    float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
```

#### Ease3.GoColor
Starts an easing animation on the color of a Image component or the background color of the main camera from a starting value to an ending value.

```csharp
IEnumerator GoColor(MonoBehaviour m, Vector3 from, Vector3 to, float time,
    Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear,
    float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
```

#### Ease3.GoColorTo
Starts an easing animation on the color of a Image component or the background color of the main camera to a specific value.

```csharp
IEnumerator GoColorTo(MonoBehaviour m, Vector3 to, float time,
    Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear,
    float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
```

#### Ease3.GoColorBy
Starts an easing animation on the color of a Image component or the background color of the main camera by a specific value.

```csharp
IEnumerator GoColorBy(MonoBehaviour m, Vector3 by, float time,
    Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear,
    float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
```

### Ease4
The `Ease4` class provides static methods for performing easing animations on Vector4 properties, including color animations for Image components and camera backgrounds.

#### Ease4.Go
Starts an easing animation on a Vector4 property from a starting value to an ending value.

```csharp
IEnumerator Go(MonoBehaviour m, Vector4 from, Vector4 to, float time,
    Action<Vector4> update, Action complete = null, EaseType type = EaseType.Linear,
    float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
```

#### Ease4.GoColor
Starts an easing animation on the color of an Image component or the background color of the main camera.

```csharp
IEnumerator GoColor(MonoBehaviour m, Vector4 from, Vector4 to, float time,
    Action<Vector4> update = null, Action complete = null, EaseType type = EaseType.Linear,
    float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
```

#### Ease4.GoColorTo
Starts an easing animation on the color of an Image component or the background color of the main camera to a specific value.

```csharp
IEnumerator GoColorTo(MonoBehaviour m, Vector4 to, float time,
    Action<Vector4> update = null, Action complete = null, EaseType type = EaseType.Linear,
    float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
```
#### Ease4.GoColorBy
Starts an easing animation on the color of an Image component or the background color of the main camera by a specific value.

```csharp
IEnumerator GoColorBy(MonoBehaviour m, Vector4 by, float time,
    Action<Vector4> update = null, Action complete = null, EaseType type = EaseType.Linear,
    float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
```

### Extension methods
Vectors are used as parameters for the above methods instead of Color objects. To help with converting between Colors and Vectors, extension methods are made available: `Vector3.GetColor()`, `Vector4.GetColor()`, `Color.GetVector3()`, `Color.GetVector4()`, `Color.SetAlpha(float alpha)`.
