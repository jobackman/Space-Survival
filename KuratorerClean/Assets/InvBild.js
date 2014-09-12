#pragma strict
    
var allOff : boolean = false ;
var InvBild : GUITexture[] ;

function Update(){
       if(Input.GetKeyDown(KeyCode.M))
          ToggleTextures() ;
    }
function ToggleTextures(){
 InvBild = GameObject.FindObjectsOfType(GUITexture) ;
   for(var i : int = 0 ; i < InvBild.length ; i++){
     InvBild[i].guiTexture.enabled = !InvBild[i].guiTexture.enabled ;
       //alloff = !allOff ;
     }
 }