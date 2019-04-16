// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    if ($(".forces").length) {
        $("#forces").attr('disabled', 'disabled');
        
        $('.force__panel').hide();
        $('.force__repeater').hide();

        $.ajax(
            {
                url: '/api/Forces',
                type: 'GET',
                data: "",
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    $.each(data, function (index, value) {
                        //console.log(index + ": " + $(this).text());
                        $("#forces").append('<option value=' + data[index].id + '>' + data[index].name + '</option>');
                    });
                    $("#forces").attr("disabled", false);
                },
                error: function () {
                    alert("error");
                }
            });

        $(".forces__select").on("change", function () {
            if (this.value === '') {
                $('.force__panel').hide();
                $('.force__repeater').hide();
            } else {
                var value = this.value;
                var html = '';
                $.ajax(
                    {
                        url: '/api/Forces/' + value,
                        type: 'GET',
                        data: "",
                        contentType: 'application/json; charset=utf-8',
                        success: function (data) {
                            //console.log(data);
                            $('.force__name').text(data.name);
                            $('.force__description').html(data.description);
                            $('.force__telephone').text(data.telephone);
                            $('.force__url').text(data.url);
                            $('.force__url').attr('href', data.url);
                            $('.force__panel').show();
                        },
                        error: function () {
                            alert("error");
                        }
                    });

                $.ajax(
                    {
                        url: '/api/Forces/' + value + '/people',
                        type: 'GET',
                        data: "",
                        contentType: 'application/json; charset=utf-8',
                        success: function (data) {
                            //console.log(data);
                            $.each(data, function (index, person) {
                                console.log(person);
                                html = html + '<div class="col-sm-6 col-md-4"><div class="panel panel-default"><div class="panel-heading"><h4 class="panel-title">' + person.name+ '</h4></div><div class="panel-body"><p>' + person.rank + '</p><a href="' + person.contact_details.twitter + '" target="_blank">' + person.contact_details.twitter + '</a></div></div></div>';
                            });
                            $('.force__repeater').html(html);
                            $('.force__repeater').show();
                        },
                        error: function () {
                            alert("error");
                        }
                    });
            }
        });
    }

    if ($(".streetcrime").length) {
        $(".streetcrime_boundary__select").attr("disabled", true);
        $("#date").attr("disabled", true);
        $("#latitude").attr("disabled", true);
        $("#longitude").attr("disabled", true);
        $('.streetcrimes_btn').attr("disabled", true);

        $.ajax(
            {
                url: '/api/Forces',
                type: 'GET',
                data: "",
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    $.each(data, function (index, value) {
                        //console.log(index + ": " + $(this).text());
                        $("#forces").append('<option value=' + data[index].id + '>' + data[index].name + '</option>');
                    });
                    $("#forces").attr("disabled", false);
                },
                error: function () {
                    alert("error");
                }
            });

        $(".streetcrime_forces__select").on("change", function () {
            $(".streetcrime_boundary__select").attr("disabled", true);
            if (this.value === '') {
                $(".streetcrime_boundary__select").find('option').not(':first').remove();
            } else {
                var value = this.value;
                $.ajax(
                    {
                        url: '/api/Neighbourhoods/' + value,
                        type: 'GET',
                        data: "",
                        contentType: 'application/json; charset=utf-8',
                        success: function (data) {
                            //console.log(data);
                            $(".streetcrime_boundary__select").find('option').not(':first').remove();
                            $.each(data, function (index, value) {
                                $(".streetcrime_boundary__select").append('<option value=' + data[index].id + '>' + data[index].name + '</option>');
                            });
                            $(".streetcrime_boundary__select").attr("disabled", false);
                        },
                        error: function () {
                            alert("error");
                        }
                    });
            }
        });

        $('.streetcrime_boundary__select').on('change', function () {
            var force = $(".streetcrime_forces__select").children("option:selected").val();
            $.ajax(
                {
                    url: '/api/Neighbourhoods/' + force + "/" + this.value,
                    type: 'GET',
                    data: "",
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {
                        //console.log(data);
                        $("#date").attr("disabled", false);
                        $("#latitude").val(data.centre.latitude).attr("disabled", false);
                        $("#longitude").val(data.centre.longitude).attr("disabled", false);
                    },
                    error: function () {
                        alert("error");
                    }
                });
        });

        $("#date").on('change', function() {
                $('.streetcrimes_btn').attr("disabled", false);
        });

        $("form").submit(function (e) {
            e.preventDefault(e);

            var force = $(".streetcrime_forces__select").children("option:selected").val();;
            var latitude = $("#latitude").val();
            var longitude = $("#longitude").val();
            var date = $("#date").children("option:selected").val();;

            $.ajax(
                {
                    url: '/api/CrimesStreet/LatitudeLongitude/' + force + '/' + latitude + '/' + longitude + '/' + date,
                    type: 'GET',
                    data: "",
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {
                        //console.log(data);
                        renderMap(longitude, latitude, data);
                    },
                    error: function () {
                        alert("error");
                    }
                });
        });
    }
});

function renderMap(longitude, latitude, data) {
    var map = new atlas.Map("map", {
        center: [parseFloat(longitude), parseFloat(latitude)],
        zoom: 12,

        //Add your Azure Maps subscription key to the map SDK. Get an Azure Maps key at https://azure.com/maps
        authOptions: {
            authType: 'subscriptionKey',
            subscriptionKey: 'QkfkjFHexLa5xAIXdL7luzO-MEww6lZgLdudFq_2780'
        }
    });

    //Wait until the map resources are ready.
    map.events.add('ready', function () {

        /* Construct a zoom control*/
        var zoomControl = new atlas.control.ZoomControl();

        /* Add the zoom control to the map*/
        map.controls.add(zoomControl, {
            position: "bottom-right"
        });

        /*Add point locations*/
        const groupedData = groupBy(data, d => d.category);
        console.log(groupedData);

        for (const [key, value] of groupedData.entries()) {
            //console.log(key, value);
            //console.log(key);

            var points = [];
            for (var i = 0; i < value.length; i++) {
                var longitude = parseFloat(value[i].location.longitude);
                var latitude = parseFloat(value[i].location.latitude);
                points.push(new atlas.data.Point([longitude, latitude]));
            }

            /*Create a data source and add it to the map*/
            var dataSource2 = new atlas.source.DataSource();
            map.sources.add(dataSource2);
            /*Add multiple points to the data source*/
            dataSource2.add(points);

            var colour;
            switch (key) {
                case "anti-social-behaviour":
                    colour = "#ff3300";
                break;
                case "bicycle-theft":
                    colour = "#33cc33";
                    break;
                case "burglary":
                    colour = "#0033cc";
                    break;
                case "criminal-damage-arson":
                    colour = "#9933ff";
                    break;
                case "drugs":
                    colour = "#660033";
                    break;
                case "other-theft":
                    colour = "#ffcc00";
                    break;
                case "robbery":
                    colour = "#cc6600";
                    break;
                case "shoplifting":
                    colour = "#ff6666";
                    break;
                case "theft-from-the-person":
                    colour = "#666633";
                    break;
                case "vehicle-crime":
                    colour = "#666699";
                    break;
                case "violent-crime":
                    colour = "#66ff33";
                    break;
                default:
                    // other-crime
                    colour = "#4288f7";
                    break;
            }

            //Create a bubble layer to render the filled in area of the circle, and add it to the map.*/
            var bubbleLayer = new atlas.layer.BubbleLayer(dataSource2, null, {
                radius: 5,
                strokeColor: colour,
                strokeWidth: 4,
                color: "white"
            });
            map.layers.add(bubbleLayer);

            ////When the mouse is over the cluster and icon layers, change the cursor to a pointer.
            //map.events.add('mouseover', [bubbleLayer], function () {
            //    map.getCanvasContainer().style.cursor = 'pointer';
            //});

            ////When the mouse leaves the item on the cluster and icon layers, change the cursor back to the default (grab).
            //map.events.add('mouseout', [bubbleLayer], function () {
            //    map.getCanvasContainer().style.cursor = 'grab';
            //    hidePopup();
            //});

            ////Add a click event to the icon layer and show the shape that was selected.
            //map.events.add('click', bubbleLayer, function (e) {
            //    //showPopup(e.shapes[0]);
            //    symbolFocused(map, e.shapes[0]);
            //});

            //map.events.add('mouseover', bubbleLayer, symbolFocused(map));
        }

        //Create a pop-up window, but leave it closed so we can update it and display it later.
        popup = new atlas.Popup({
            pixelOffset: [0, -18],
            closeButton: false
        });

    });
}

//function symbolFocused(map, e) {
//    //Define an HTML template for a custom popup content laypout.
//    var popupTemplate = '<div class="customInfobox"><div class="name">{name}</div>{description}</div>';

//    var content, coordinate;
//    var properties = e.getProperties();
//    content = popupTemplate.replace(/{name}/g, properties._azureMapsShapeId).replace(/{description}/g, properties._azureMapsShapeId);
//    coordinate = e.getCoordinates();

//    var popup = new atlas.Popup({
//        pixelOffset: [0, -18],
//        closeButton: false
//    });

//    popup.setOptions({
//        //Update the content of the popup.
//        content: content,

//        //Update the popup's position with the symbol's coordinate.
//        position: coordinate

//    });
//    //Open the popup.
//    popup.open(map);
//}

//function hidePopup() {
//    popup.close();
//}

function groupBy(list, keyGetter) {
    const map = new Map();
    list.forEach((item) => {
        const key = keyGetter(item);
        const collection = map.get(key);
        if (!collection) {
            map.set(key, [item]);
        } else {
            collection.push(item);
        }
    });
    return map;
}

//function showPopup(e) {
//    //Get the properties and coordinates of the first shape that the event occured on.

//    var p = e.shapes[0].getProperties();
//    var position = e.shapes[0].getCoordinates();

//    //Create HTML from properties of the selected result.
//    var html = ['<div style="padding:5px"><div><b>', p.poi.name,
//        '</b></div><div>', p.address.freeformAddress,
//        '</div><div>', position[1], ', ', position[0], '</div></div>'];

//    //Update the content and position of the popup.
//    popup.setPopupOptions({
//        content: html.join(''),
//        position: position
//    });

//    //Open the popup.
//    popup.open(map);
//}

//function showPopup2(shape) {
//    var properties = shape.getProperties();

//    /* Generating HTML for the pop-up window that looks like this:

//        <div class="storePopup">
//            <div class="popupTitle">
//                3159 Tongass Avenue
//                <div class="popupSubTitle">Ketchikan, AK 99901</div>
//            </div>
//            <div class="popupContent">
//                Open until 22:00 PM<br/>
//                <img title="Phone Icon" src="images/PhoneIcon.png">
//                <a href="tel:1-800-XXX-XXXX">1-800-XXX-XXXX</a>
//                <br>Amenities:
//                <img title="Wi-Fi Hotspot" src="images/WiFiIcon.png">
//                <img title="Wheelchair Accessible" src="images/WheelChair-small.png">
//            </div>
//        </div>
//    */

//    var html = ['<div class="storePopup">'];
//    html.push('<div class="popupTitle">',
//        //properties['AddressLine'],
//        '<div class="popupSubTitle">',
//        //getAddressLine2(properties),
//        '</div></div><div class="popupContent">',

//        //Convert the closing time to a format that's easier to read.
//        //getOpenTillTime(properties),

//        //Route the distance to two decimal places.  
//        '<br/>', (Math.round(shape.distance * 100) / 100),
//        ' miles away',
//        '<br /><img src="images/PhoneIcon.png" title="Phone Icon"/><a href="tel:',
//        //properties['Phone'],
//        '">',
//        //properties['Phone'],
//        '</a>'
//    );

//    //if (properties['IsWiFiHotSpot'] || properties['IsWheelchairAccessible']) {
//    //    html.push('<br/>Amenities: ');

//    //    if (properties['IsWiFiHotSpot']) {
//    //        html.push('<img src="images/WiFiIcon.png" title="Wi-Fi Hotspot"/>')
//    //    }

//    //    if (properties['IsWheelchairAccessible']) {
//    //        html.push('<img src="images/WheelChair-small.png" title="Wheelchair Accessible"/>')
//    //    }
//    //}

//    html.push('</div></div>');

//    //Update the content and position of the pop-up window for the specified shape information.
//    popup.setOptions({

//        //Create a table from the properties in the feature.
//        content: html.join('')//,
//        //position: shape.getCoordinates()
//    });

//    //Open the pop-up window.
//    popup.open(map);
//}