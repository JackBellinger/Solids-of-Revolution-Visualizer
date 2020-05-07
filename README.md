HoloLens Horizons: Solids of Revolution
Jackson Bellinger, Kyle Kestner, Sean McGee, Preston Mouw

Camera Controls: The user may operate the camera by using following keyboard keys and mouse inputs:
↑ (up arrow) / W: Rotates camera up.
↓ (down arrow) / S: Rotates camera down.
→ (right arrow) / D: Pans camera right.
← (left arrow) / A: Pans camera left.
+ / Scroll Mouse Wheel Forward: Zooms the camera in.
- / Scroll Mouse Wheel Backward: Zooms the camera out.


Menus:
There are two menus that are visible once the application is running. A function menu is located on the left side of the screen, and a bounds manager menu is located on the right.
Menu Controls: The menus are operated by clicking on their respective buttons with the left mouse button. Their functionalities are described below.

Function Menu:
The function menu is located on the left side of the screen and is controlled through mouse movements. To pull up a preset function, left click the associated button.
Function Legend:
- x: y = x
- x2: y = x^2
- x3: y = x^3
- sqrt: y = sqrt(x) (square root)
- sin: y = sin(x)
- cos: y = cos(x)
- exp: y = e^x (exponential)
- const: y = 1 (constant)
- recip: y = 1/x (reciprocal)

Once you select an equation, a 2D render of the function will be displayed. Text on the function menu will change to display certain controls. These controls are described later below.

Bounds Menu: 
The bounds manager menu is located on the right side of the screen and is also controlled through mouse movements. This will set the bounds of the function on the x-axis.
This should be set first before selecting and generating your function. The bounds are set to (0, 1) by default.
Selecting the buttons next to the label "Left Bound" will alter the value of the left bound, displayed initially as '0' to the right of the buttons.
Selecting the buttons next to the label "Right Bound" will alter the value of the right bound, displayed initially as '1' to the right of the buttons.
There are two pairs of buttons labeled '-' and '+'. The range of values for both bounds range from (0, 2pi), with error checking to prevent the left bound from exceeding the right bound.
Selecting the '-' button will decrement the respective bound, while '+' will increment the respective bound.
The values that are incremented by include approximations of pi with increments of pi/4 up to 2pi maximum, and quarter increments from 0-5.

V: The 'v' key will hide/show the menus.


The user may also draw their own function with the Canvas tool.

B: The 'b' key will active/deactivate Canvas mode.

Canvas mode: Camera controls are replaced with brush movements. The brush will track where it has moved to create free hand functions. The function can be
	saved to the axis by either ending Canvas mode early by pressing the 'b' key, or automatically after enough has been drawn.

Canvas Controls:
↑ (up arrow) / W: Moves brush up in Canvas mode.
↓ (down arrow) / S: Moves brush down in Canvas mode.
→ (right arrow) / D: Moves brush right in Canvas mode.
← (left arrow) / A: Moves brush left in Canvas mode.


Once an equation has been selected, or has been drawn by the user, the following keyboard keys will be active:
C: The 'c' key will clear any on screen function or solid. Use this when you want to display a different function.
M: The 'm' key will rotate the on screen function around the x axis.
N: The 'n' key will rotate the on screen function around the y axis.

Pressing either the M/N keys will display the surface area and volume for the rotated function's object on the function menu.
The Volume and Surface area readouts are not subject to be accurate unless the object being rotated is a mathematical function. i.e. sin on [0,2pi] around the y axis is not a function.
