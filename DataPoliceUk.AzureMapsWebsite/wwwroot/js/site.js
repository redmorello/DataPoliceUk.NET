// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    if ($(".forces").length) {
        $("#forces").attr('disabled', 'disabled');
        
        $('.force__panel').hide();
        $('.force__repeater').hide();
        $('.spinner-border').show();

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
                    $('.spinner-border').hide();
                },
                error: function () {
                    alert("error");
                }
            });

        $(".forces__select").on("change", function () {
            $('.force__panel').hide();
            $('.force__repeater').hide();
            $('.spinner-border').show();
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
                        $('.spinner-border').hide();
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
                            html = html + '<div class="col-sm-6 col-md-4"><div class="card bg-light mb-3"><div class="card-body"><h5 class="card-title">' + person.name + '</h5><p class="card-text">' + person.rank + '</p><a href="' + person.contact_details.twitter + '" target="_blank">' + person.contact_details.twitter + '</a></p></div></div></div>';
                        });
                        $('.force__repeater').html(html);
                        $('.force__repeater').show();
                        $('.spinner-border').hide();
                    },
                    error: function () {
                        alert("error");
                        $('.spinner-border').hide();
                    }
                });
        });
    }

    if ($(".streetcrime").length) {
        $(".streetcrime_boundary__select").attr("disabled", true);
        $("#date").attr("disabled", true);
        $("#latitude").attr("disabled", true);
        $("#longitude").attr("disabled", true);
        $('.streetcrimes_btn').attr("disabled", true);
        $("#map").hide();
        $('.spinner-border').show();

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
                    $('.spinner-border').hide();
                },
                error: function () {
                    alert("error");
                    $('.spinner-border').hide();
                }
            });

        $(".streetcrime_forces__select").on("change", function () {
            $(".streetcrime_boundary__select").attr("disabled", true);
            $('.spinner-border').show();
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
                            $('.spinner-border').hide();
                        },
                        error: function () {
                            alert("error");
                            $('.spinner-border').hide();
                        }
                    });
            }
        });

        $('.streetcrime_boundary__select').on('change', function () {
            $('.spinner-border').show();
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
                        $("#latitude").val(data.centre.latitude); //.attr("disabled", false);
                        $("#longitude").val(data.centre.longitude); //.attr("disabled", false);
                        $('.spinner-border').hide();
                    },
                    error: function () {
                        alert("error");
                        $('.spinner-border').hide();
                    }
                });
        });

        $("#date").on('change', function() {
                $('.streetcrimes_btn').attr("disabled", false);
        });

        $("form").submit(function (e) {
            e.preventDefault(e);

            $('.spinner-border').show();
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
                        $("#map").show();
                        renderMap(longitude, latitude, data);                        
                    },
                    error: function () {
                        alert("error");
                        $('.spinner-border').hide();
                    }
                });
        });
    }
});

function renderMap(longitude, latitude, data) {
    var map = new atlas.Map("map", {
        center: [parseFloat(longitude), parseFloat(latitude)],
        zoom: 13,

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
                    colour = "#66ff33";
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
                    colour = "#33cc33";
                    break;
                default:
                    // other-crime
                    colour = "#4288f7";
                    break;
            }

            //Create a bubble layer to render the filled in area of the circle, and add it to the map.*/
            var bubbleLayer = new atlas.layer.BubbleLayer(dataSource2, null, {
                radius: 3,
                strokeColor: colour,
                strokeWidth: 2,
                color: colour
            });
            map.layers.add(bubbleLayer);
        }

        //Create a pop-up window, but leave it closed so we can update it and display it later.
        popup = new atlas.Popup({
            pixelOffset: [0, -18],
            closeButton: false
        });

        $('.spinner-border').hide();
    });
}

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