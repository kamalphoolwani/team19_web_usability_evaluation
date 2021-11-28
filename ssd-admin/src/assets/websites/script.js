//Configuration object for Heatmap
var config = {
    container: document.getElementById('heatmapContainer'),
    radius: 100,
    maxOpacity: .5,
    minOpacity: 0,
    blur: .75
};


//Array to store X,Y coordinates and value
var dataPoints = [];

//Generates the heat map from the array of coordinates
var jsondata;
function Stor(j)
{
    jsondata=j;
    Object.entries(jsondata).forEach(([key, v]) => {
        d={
        x: v["xPos"],
        y: v["yPos"],
        value: v["intensity"]
        };
        dataPoints.push(d);
    });
    var heatmapInstance = window.h337.create(config);

    heatmapInstance.addData(dataPoints);
}


//Fetches the coordinates from API
function finishHeatMap(){

    fetch('https://projectssdapiadmin20211126215408.azurewebsites.net/api/clickevent/getall') 
    .then(response => response.json())
    .then(json => Stor(json))
    .catch(err => console.log('Request Failed', err)); // Catch errors

}

