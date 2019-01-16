$(document).ready(function () {
        //initial request, to load offers from Cluj
        $.get(refreshCities+'Cluj', function (data, status) {
            $('#offers').html('');
            if (data.length > 0) {
                $(data).each(function (index, element) {
                    var urlToOfferProfile = '<a href="' + offerProfile + element.Id + '">' + element.Name + '</a>';
                    var urlToOwnerProfile = '<a href="' + ownerProfile + element.OwnerId + '">' + element.Owner + '</a>';
                    //var htmlEl = '<div class="thumbnail"><h3>' + urlToOfferProfile + '</h3><p>&emsp; by ' + urlToOwnerProfile + '</p><p>&emsp; at ' + element.Location + '</p></div>';
                    var htmlEl = '<div class="thumbnail">' +
                        '<img src="https://isobm2016congress.com/wp-content/uploads/2016/01/candidate_icon_b2.png" alt="offer_icon" height="42" width="42">' +
                        '<div class="row">' +
                        '<div class="col-md-offset-5">' +
                        '<h3>' + urlToOfferProfile + '</h3>' +
                        '</div>' +
                        '</div>' +
                        '<p>&emsp; <b>By: </b>' + urlToOwnerProfile + ' </p>' +
                        '<p>&emsp; <b>Location: </b>' + element.Location + '</p>' +
                        '<p>&emsp; <b>Time: </b>' + element.DateTimeUTC + '</p>' +
                        '</div>';

                    $('#offers').append(htmlEl);
                });
            } else {
                $('#offers').html('No offers from ' + cityName + ' could be found!');
            }
        });

        $('#locationSelect').change(function () {
        var btn = $(this);
        var cityName = $('#locationSelect').val();
        $('#offers').html('Loading offers from ' + cityName + '...');
        $('.btn').removeClass('btn-primary');
        $(btn).addClass('btn-primary');
        var url = refreshCities + cityName
        $.get(url, function (data, status) {
            $('#offers').html('');
            if (data.length > 0) {
                $(data).each(function (index, element) {
                   
                    var urlToOfferProfile = '<a href="'+offerProfile + element.Id+'">'+element.Name+'</a>';
                    var urlToOwnerProfile = '<a href="'+ownerProfile + element.OwnerId+'">'+element.Owner+'</a>';
                    //var htmlEl = '<div class="thumbnail"><h3>' + urlToOfferProfile + '</h3><p>&emsp; by ' + urlToOwnerProfile + '</p><p>&emsp; at ' + element.Location + '</p></div>';
                    var htmlEl = '<div class="thumbnail">' +
                        '<img src="https://isobm2016congress.com/wp-content/uploads/2016/01/candidate_icon_b2.png" alt="offer_icon" height="42" width="42">' +
                        '<div class="row">' +
                        '<div class="col-md-offset-5">' +
                        '<h3>' + urlToOfferProfile + '</h3>' +
                        '</div>' +
                        '</div>' +
                        '<p>&emsp; <b>By: </b>' + urlToOwnerProfile +' </p>' +
                        '<p>&emsp; <b>Location: </b>'+ element.Location +'</p>'+
                        '<p>&emsp; <b>Time: </b>' + element.DateTimeUTC +'</p>'+
                        '</div>';
                    $('#offers').append(htmlEl);
                });
            } else {
                $('#offers').html('No offers from ' + cityName + ' could be found!');
            }
        });
    });
});