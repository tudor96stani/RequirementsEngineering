$(document).ready(function () {
        //initial request, to load events from Cluj
        $.get(refreshCities+'Cluj', function (data, status) {
            $('#events').html('');
            if (data.length > 0) {
                $(data).each(function (index, element) {
                    var urlToEventProfile = '<a href="' + eventProfile + element.Id + '">' + element.Name + '</a>';
                    var urlToOwnerProfile = '<a href="' + ownerProfile + element.OwnerId + '">' + element.Owner + '</a>';
                    //var htmlEl = '<div class="thumbnail"><h3>' + urlToEventProfile + '</h3><p>&emsp; by ' + urlToOwnerProfile + '</p><p>&emsp; at ' + element.Location + '</p></div>';
                    var htmlEl = '<div class="thumbnail">' +
                        '<img src="https://isobm2016congress.com/wp-content/uploads/2016/01/volunteer_icon_b2.png" alt="event_icon" height="42" width="42">' +
                        '<div class="row">' +
                        '<div class="col-md-offset-5">' +
                        '<h3>' + urlToEventProfile + '</h3>' +
                        '</div>' +
                        '</div>' +
                        '<p>&emsp; <b>By: </b>' + urlToOwnerProfile + ' </p>' +
                        '<p>&emsp; <b>Location: </b>' + element.Location + '</p>' +
                        '<p>&emsp; <b>Time: </b>' + element.DateTimeUTC + '</p>' +
                        '</div>';

                    $('#events').append(htmlEl);
                });
            } else {
                $('#events').html('No offers from ' + cityName + ' could be found!');
            }
        });

        $('#locationSelect').change(function () {
        var btn = $(this);
        var cityName = $('#locationSelect').val();
        $('#events').html('Loading offers from ' + cityName + '...');
        $('.btn').removeClass('btn-primary');
        $(btn).addClass('btn-primary');
        var url = refreshCities + cityName
        $.get(url, function (data, status) {
            $('#events').html('');
            if (data.length > 0) {
                $(data).each(function (index, element) {
                   
                    var urlToEventProfile = '<a href="'+eventProfile + element.Id+'">'+element.Name+'</a>';
                    var urlToOwnerProfile = '<a href="'+ownerProfile + element.OwnerId+'">'+element.Owner+'</a>';
                    //var htmlEl = '<div class="thumbnail"><h3>' + urlToEventProfile + '</h3><p>&emsp; by ' + urlToOwnerProfile + '</p><p>&emsp; at ' + element.Location + '</p></div>';
                    var htmlEl = '<div class="thumbnail">' +
                        '<img src="https://isobm2016congress.com/wp-content/uploads/2016/01/volunteer_icon_b2.png" alt="event_icon" height="42" width="42">' +
                        '<div class="row">' +
                        '<div class="col-md-offset-5">' +
                        '<h3>' + urlToEventProfile + '</h3>' +
                        '</div>' +
                        '</div>' +
                        '<p>&emsp; <b>By: </b>' + urlToOwnerProfile +' </p>' +
                        '<p>&emsp; <b>Location: </b>'+ element.Location +'</p>'+
                        '<p>&emsp; <b>Time: </b>' + element.DateTimeUTC +'</p>'+
                        '</div>';
                    $('#events').append(htmlEl);
                });
            } else {
                $('#events').html('No offers from ' + cityName + ' could be found!');
            }
        });
    });
});