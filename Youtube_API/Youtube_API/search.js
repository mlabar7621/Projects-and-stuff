// Your use of the YouTube API must comply with the Terms of Service:
// https://developers.google.com/youtube/terms
// Called automatically when JavaScript client library is loaded.
function onClientLoad() {
    gapi.client.load('youtube', 'v3', onYouTubeApiLoad);
}
// Called automatically when YouTube API interface is loaded (see line 9).
function onYouTubeApiLoad() {
    gapi.client.setApiKey('AIzaSyBfS5fKWJdptcEDEowkie2IwgwH7gIqy3w');
}

// Called when the search button is clicked in the html code
function search() {
    var query = document.getElementById('query').value;
    // Use the JavaScript client library to create a search.list() API call.
    var request = gapi.client.youtube.search.list({
        part: 'snippet',
        q: query
    });
    // Send the request to the API server, call the onSearchResponse function when the data is returned
    request.execute(onSearchResponse);
}
// Triggered by this line: request.execute(onSearchResponse);
function onSearchResponse(response) {
    var responseString = JSON.stringify(response, '', 2);
    var arr = response.items;

    var obj = arr[0];
    arrSearchResults(arr);
}

function arrSearchResults(arr)
{
    $("#content").empty();
    for(var i = 0; i < arr.length; i++)
    {
        var title = arr[i].snippet.title;
        var img = arr[i].snippet.thumbnails.default.url;
        var link = arr[i].id.videoId;
        var desc = arr[i].snippet.description;
        $("#content").append(`<a href="https://youtube.com/watch?v=${link}" id="${i}">`);``
        $(`#${i}`).append(`<p>${title}</p>`);
        $(`#${i}`).append(`<div id="Details${i}"></div>`)
        $(`#Details${i}`).append(`<div style="display:inline-block; vertical-align:top"><img src="${img}"></div>`);
        $(`#Details${i}`).append(`<div style="display:inline-block; vertical-align:top"><p style="text-decoration:none; color:black; margin:0;">${desc}</p></div>`);
    }
}