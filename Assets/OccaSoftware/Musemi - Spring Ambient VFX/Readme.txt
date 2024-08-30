README
================================

About
--------------------------------
Musemi is a Springtime Ambient Visual Effect asset. It includes stylized wind, flyaway grass, ambient small particles, and ambient large bokeh. Each is included at 3 levels of intensity and has a variety of exposed parameters including spawn boundaries, spawn rate, size, color, lifetime, etc.

It includes a Global Wind controller and Global Wind inheritor MonoBehaviours that enable you to easily control the wind direction and speed for all Musemi Visual Effects across an entire scene.


Installation Instructions
--------------------------------
1. Import Visual Effect Graph from the Package Manager
2. Import Musemi into your Project
3. Validate that the Visual Effect Assets have been correctly imported and compiled into your project. Do this by opening the ~/Musemi/VisualEffects folder, then opening each Visual Effect Asset and clicking Compile.

Improtant Note: If Visual Effect Graph is not present in your project prior to importing Musemi, the asset may not work correctly. Please ensure that Visual Effect Graph is installed in your Project prior to importing Musemi.
Note: Unity may throw the following Shader warning when compiling Visual Effect Assets with the Set Position (Shape: Cone) node. This warning can be safely ignored.
Shader warning in '[...] Initialize Particle': pow(f, e) will not work for negative f, use abs(f) or conditionally handle negative values if you expect them at kernel CSMain at [...].vfx(n) (on [...])


Usage Instructions
--------------------------------
1. Drag and drop the SetGlobalWind prefab into your scene to configure the scene's wind settings. The forward vector of this game object defines the wind direction.
2. Drag and drop the Visual Effects you'd like to use into your scene. There are 4 sets of Visual Effects split up into 3 levels of intensity for each effect. 
     2a. You can customize the effect itself using the exposed parameters.
     2b. You can also customize the Visual Effect Graph asset itself.
3. If you are using the Global Wind functionality, ensure that the Visual Effect game objects include a GetGlobalWind MonoBehaviour, included in the Scripts folder.

Note: The Demo Resources are included as part of  the demo scene but are not intended to stand alone as part of this asset package. That being said, feel free to use and modify it under the restrictions set out within the purchasing license.


Requirements
--------------------------------
This asset is designed for Unity 2020.3, Universal Render Pipeline. It should also work on High Definition Render Pipeline, however the ground plane uses a URP Shader, so the Ground plane itself maynot render correctly on initial load.


Support
--------------------------------
If you're not happy, I'm not happy.
Please contact me at occasoftware@gmail.com for any support.
