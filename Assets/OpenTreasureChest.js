var door : GameObject; private var HasBeenTriggered : int;

HasBeenTriggered = 0;

function OnTriggerEnter (collision : Collider) 
{ if (collision.gameObject.tag == "Door") 
	{ if(HasBeenTriggered == 0) 
		{ door.animation.Play ();
		 HasBeenTriggered = 1; } } }