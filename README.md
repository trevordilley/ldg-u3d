# Todo:
[ ] Move the characters around
[ ] Get the FoV rendering looking nice
[ ] Have the characters animate
[ ] Have the characters respect the collision layer
[ ] Have the characters actually path intelligently (make a grid of way points? maybe there is a unity thing we can use?)
[ ] Add bad guys
	[ ] Health System
	[ ] Action system
		[ ] Melee attacks
	[ ] Damage system
	[ ] Angle of vulnerability 
	[ ] Stamina System
[ ] Add loot
[ ] Add hauling
[ ] Add Death timer
[ ] Add Death timer effects
[ ] Add Healing/Stabilizing
---- Doing that stuff above reaches parity with LibGdx ----
[ ] Meta balls renderer
[ ] Mage character with animation
[ ] Growing field of influence (based on metaballs?) 
	[ ] meta balls can only move within a field of influence
	[ ] They move slowly? Some move quickly?
	[ ] Some places have "ley lines" which are static universal
	fields of influence


# FoV Rendering

HardLight2D helps us figure out the dynamic FoV, however to make the rest of the world dark and black
we need to use some fancy rendering tom-foolery with Stencil Buffers.

Here's a youtube video: https://www.youtube.com/watch?v=CSeUMTaNFYk&t=1126s
Here's the thread where I found it: https://stackoverflow.com/questions/70172772/unity-only-render-objects-from-a-layer-inside-a-2d-mesh
