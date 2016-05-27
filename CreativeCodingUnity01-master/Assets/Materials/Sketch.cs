using UnityEngine;
using Pathfinding.Serialization.JsonFx;
public class Sketch : MonoBehaviour {
	public GameObject myPrefab;
	public string _WebsiteURL = "http://testinfomgmt192.azurewebsites.net/tables/SpreadSheetIFTTT?zumo-api-version=2.0.0";

	void Start () {
		//Reguest.GET can be called passing in your ODATA url as a string in the form:
		//http://{Your Site Name}.azurewebsites.net/tables/{Your Table Name}?zumo-api-version=2.0.0
		//The response produce is a JSON string
		string jsonResponse = Request.GET(_WebsiteURL);

		//Just in case something went wrong with the request we check the reponse and exit if there is no response.
		if (string.IsNullOrEmpty(jsonResponse))
		{
			return;
		}

		//We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
		Trello[] trellos = JsonReader.Deserialize<Trello[]>(jsonResponse);

		//----------------------
		//YOU WILL NEED TO DECLARE SOME VARIABLES HERE SIMILAR TO THE CREATIVE CODING TUTORIAL
		/* testinfomgmt192 */
		int i = 0; 
		/* testinfomgmt192 */ 




		//----------------------

		//We can now loop through the array of objects and access each object individually
		foreach (Trello trello in trellos)
		{
			//Example of how to use the object
			//Debug.Log("This products name is: " + trello.Title);

			/* testinfomgmt192 */
			Debug.Log(trello.Title);
			/* testinfomgmt192 */

			//----------------------
			//YOUR CODE TO INSTANTIATE NEW PREFABS GOES HERE

			/* testinfomgmt192 */ 
			int totalCubes = 25;

			float totalDistance = 2.9f;

			float perc = i / (float)totalCubes;
			float sin = Mathf.Sin(perc * Mathf.PI / 2);

			float x = 1.8f + sin * totalDistance;
			float y = 5.0f;
			float z = 0.0f;

			var newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity); //Quaternion is default identity;
			newCube.GetComponent<CubeScript>().SetSize((1.0f - perc));
			newCube.GetComponent<CubeScript>().rotateSpeed = .2f + perc * 4.0f;
			newCube.GetComponentInChildren<TextMesh>().text = trello.Title;

			i++;
			/* testinfomgmt192 */


			//----------------------
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}
}
