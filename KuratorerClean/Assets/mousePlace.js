#pragma strict
 
var spawnAreas : LayerMask; //Layers where you can spawn objects, make sure to fill this out
var destroyableObjects : LayerMask; //Objects that is ok to destroy, make sure to fill this out

var spawnPrefab : GameObject; //The object you want to spawn, in case you didn't assign the script creates a primitive

var spawnPrefabs : GameObject[];
var nummer : int;
var grid : Vector3 = Vector3(1,1,1); //The grid you want to instantiate objects by
var colliderSize : Vector3 = Vector3(1,1,1); //The collider size of the object
var cam : Camera; //The camera you're using, in case you didn't assign one the script assigns the Main Camera
private var range : float = 5000.0; //Don't use infinity, use the camera's far clipping plane if you need to
private var hit : RaycastHit;

//public OVRCrosshairPlace(ref OVRCrosshair  : 
//public Vector3 		CameraRootPosition = new Vector3(0.0f, 1.0f, 0.0f);	

//var fram : GameObject;
//fram = new GameObject("fram");

var horizontalSpeed : float = 2.0;
var verticalSpeed : float = 2.0;

function Start () {
    cam = Camera.main;
}
 
function Update () {


		//Debug.Log (fYRot);
    if (Input.GetMouseButtonDown(0))
        Build();
    if (Input.GetMouseButtonDown(1))
        Erase(); 
	
	if (Input.GetKeyDown(KeyCode.Alpha1)) 
		nummer = 0;
	if (Input.GetKeyDown(KeyCode.Alpha2)) 
		nummer = 1; 
	if (Input.GetKeyDown(KeyCode.Alpha3)) 
		nummer = 2; 
	if (Input.GetKeyDown(KeyCode.Alpha4)) 
		nummer = 3; 
	if (Input.GetKeyDown(KeyCode.Alpha5)) 
		nummer = 4; 
	
	//
	//var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
	//var hit : RaycastHit;
	//if (Physics.Raycast (ray, hit, 100)) {
	//	Debug.DrawLine (ray.origin, hit.point);
	//Debug.DrawRay (transform.position, forward, Color.green);

	
	//
	}

function Build () {
    var fYRot : float = Camera.mainCamera.transform.eulerAngles.y;
    //var fYRot = (ImageCrosshair.height * 0.5f);
    if (HitBlock(spawnAreas)) {
       if (spawnPrefab==null) {
         //In case you didn't have a prefab we spawn a primitive
         spawnPrefab = GameObject.CreatePrimitive(PrimitiveType.Cube);
         //spawnPrefab.transform.position = Grid(hit.point);
         spawnPrefab.transform.position = Grid(hit.point);
       } else {
        
         //You have a prefab, let's spawn it

		//var spawnObject = Instantiate(spawnPrefab, Grid(hit.point), Quaternion.Euler(0,fYRot ,0)) ;
		
		var spawnObject = Instantiate(spawnPrefabs[(nummer)], Grid(hit.point), Quaternion.Euler(0,fYRot,0)) ;
        //var spawnObject = Instantiate(spawnPrefab, Grid(hit.point), Quaternion.Euler(0f,0f ,0f)) ;
		
              }
    }
}


function Erase () {
    if (HitBlock(destroyableObjects))
       Destroy(hit.transform.gameObject);
}
 
function HitBlock (mask : LayerMask) : boolean {
    //var forward : Vector3 = transform.TransformDirection(Vector3.forward) * 10;
	//var fwd = transform.TransformDirection (Vector3.forward);
	//var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
	//return Physics.Raycast(ray, RaycastHit, 100, mask);
    var ray = cam.ScreenPointToRay (Input.mousePosition);
    return Physics.Raycast(ray, hit, range, mask);
}
 
function Grid (pos : Vector3) : Vector3 {
    return Vector3(Mathf.Round(pos.x/grid.x)*grid.x-(colliderSize.x/2), Mathf.Round(pos.y/grid.y)*grid.y+(colliderSize.y/2), Mathf.Round(pos.z/grid.z)*grid.z-(colliderSize.z/2));
	//return Vector3(Mathf.Round(pos.x/grid.x)*grid.x-(colliderSize.x/2), Mathf.Round(pos.y/grid.y)*grid.y+(colliderSize.y/2), Mathf.Round(pos.z/grid.z)*grid.z-(colliderSize.z/2));
}	