// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');

    var calendar = new FullCalendar.Calendar(calendarEl, {
        plugins: ['interaction', 'dayGrid', 'timeGrid', 'resourceTimeline'],
        now: '2019-08-07',
        editable: true,
        aspectRatio: 1.8,
        scrollTime: '00:00',
        header: {
            left: 'today prev,next',
            center: 'title',
            right: 'resourceTimelineDay,resourceTimelineThreeMonths,timeGridWeek,dayGridMonth'
        },
        //defaultView: 'resourceTimelineDay',
        defaultView: 'resourceTimelineThreeMonths',
        views: {
            resourceTimelineThreeMonths: {
                type: 'resourceTimeline',
                duration: {
                    days: 90
                },
                buttonText: '3 Months'
            }
        },
        resourceAreaWidth: '30%',
        resourceColumns: [{
            labelText: 'Project',
            field: 'title'
        },
        {
            labelText: 'Status',
            field: 'occupancy'
        }
        ],
        resources: [{
            id: 'a',
            title: 'Auditorium A',
            occupancy: 40
        },
        {
            id: 'b',
            title: 'Auditorium B',
            occupancy: 40,
            eventColor: 'green'
        },
        {
            id: 'c',
            title: 'Auditorium C',
            occupancy: 40,
            eventColor: 'orange'
        },
        {
            id: 'd',
            title: 'Auditorium D',
            occupancy: 40,
            children: [{
                id: 'd1',
                title: 'Room D1',
                occupancy: 10
            },
            {
                id: 'd2',
                title: 'Room D2',
                occupancy: 10
            }
            ]
        },
        {
            id: 'e',
            title: 'Auditorium E',
            occupancy: 40
        },
        {
            id: 'f',
            title: 'Auditorium F',
            occupancy: 40,
            eventColor: 'red'
        },
        {
            id: 'g',
            title: 'Auditorium G',
            occupancy: 40
        },
        {
            id: 'h',
            title: 'Auditorium H',
            occupancy: 40
        },
        {
            id: 'i',
            title: 'Auditorium I',
            occupancy: 40
        },
        {
            id: 'j',
            title: 'Auditorium J',
            occupancy: 40
        },
        {
            id: 'k',
            title: 'Auditorium K',
            occupancy: 40
        },
        {
            id: 'l',
            title: 'Auditorium L',
            occupancy: 40
        },
        {
            id: 'm',
            title: 'Auditorium M',
            occupancy: 40
        },
        {
            id: 'n',
            title: 'Auditorium N',
            occupancy: 40
        },
        {
            id: 'o',
            title: 'Auditorium O',
            occupancy: 40
        },
        {
            id: 'p',
            title: 'Auditorium P',
            occupancy: 40
        },
        {
            id: 'q',
            title: 'Auditorium Q',
            occupancy: 40
        },
        {
            id: 'r',
            title: 'Auditorium R',
            occupancy: 40
        },
        {
            id: 's',
            title: 'Auditorium S',
            occupancy: 40
        },
        {
            id: 't',
            title: 'Auditorium T',
            occupancy: 40
        },
        {
            id: 'u',
            title: 'Auditorium U',
            occupancy: 40
        },
        {
            id: 'v',
            title: 'Auditorium V',
            occupancy: 40
        },
        {
            id: 'w',
            title: 'Auditorium W',
            occupancy: 40
        },
        {
            id: 'x',
            title: 'Auditorium X',
            occupancy: 40
        },
        {
            id: 'y',
            title: 'Auditorium Y',
            occupancy: 40
        },
        {
            id: 'z',
            title: 'Auditorium Z',
            occupancy: 40
        }
        ],
        events: [{
            id: '1',
            resourceId: 'b',
            start: '2019-08-07T02:00:00',
            end: '2019-08-07T07:00:00',
            title: 'event 1'
        },
        {
            id: '2',
            resourceId: 'c',
            start: '2019-08-07T05:00:00',
            end: '2019-08-07T22:00:00',
            title: 'event 2'
        },
        {
            id: '3',
            resourceId: 'd',
            start: '2019-08-06',
            end: '2019-08-08',
            title: 'event 3'
        },
        {
            id: '4',
            resourceId: 'e',
            start: '2019-08-07T03:00:00',
            end: '2019-08-07T08:00:00',
            title: 'event 4'
        },
        {
            id: '5',
            resourceId: 'f',
            start: '2019-08-07T00:30:00',
            end: '2019-08-07T02:30:00',
            title: 'event 5'
        }
        ]
    });
    calendar.setOption('height', window.innerHeight - 100);
    calendar.render();
});
function GoToEdit(id) {
    window.location.href = `/Bookings/Edit?id=${id}`;
}
function GoToDetails(id) {
    window.location.href = `/Bookings/Details?id=${id}`;
}

function EditRequest(url, data) {
    return fetch(url, {
        credentials: 'same-origin', // 'include', default: 'omit'
        method: 'PUT', // 'GET', 'PUT', 'DELETE', etc.
        body: JSON.stringify(data), // Coordinate the body type with 'Content-Type'
        headers: new Headers({
            'Content-Type': 'application/json'
        })
    });
}
function GetData(url) {
    return fetch(url)
        .then(response => response.json());
}
function ShowModel(data) {
    let sdate = new Date(data.startDate);
    let edate = new Date(data.endDate);
    $('#exampleModalLabel').empty();
    $('#exampleModalLabel').append(`${data.title} Details.`);
    let TableOfDistances = `<table class="table table-bordered table-dark table-hover" style="width:100%;"><thead><tr><th>Property</th><th>Value</th></tr></thead><tr><td>Title</td><td>${data.title} </td></tr><tr><td>Start Date</td><td>${sdate.getDate() + '/' + (sdate.getMonth() + 1) + '/' + sdate.getFullYear()} </td></tr><tr><td>End Date</td><td>${edate.getDate() + '/' + (edate.getMonth() + 1) + '/' + edate.getFullYear()}</td></tr><tr><td>Tool Id</td><td>${data.toolId}</td></tr></table>`;
    $('#modelBody').empty();
    $('#modelBody').append(TableOfDistances);
    $('#exampleModal').modal();
}
function bindClickEventToAllResources() {
    document.body.addEventListener("click", function (e) {
        if (e.target &&
            e.target.classList.contains("fc-cell-text")) {
            GetData(`/api/tools/${e.srcElement.innerText}`).then(response => ShowResourceModal(response));
        }
    });
}
function ShowResourceModal(data) {
    console.log(data);
    $('#exampleModalLabel').empty();
    $('#exampleModalLabel').append(`${data.title} Details.`);
    let TableOfDistances = `<table class="table table-bordered table-dark table-hover" style="width:100%;"><thead><tr><th>Property</th><th>Value</th></tr></thead><tr><td>Title</td><td>${data.title} </td></tr><tr><td>Is Complete</td><td>${data.isComplete} </td></tr></table>`;
    $('#modelBody').empty();
    $('#modelBody').append(TableOfDistances);
    $('#exampleModal').modal();
    
}