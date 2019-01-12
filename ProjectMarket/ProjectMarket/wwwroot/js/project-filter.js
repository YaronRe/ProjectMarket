function filterProjects() {
    var filter = {};
    var name = $('#Name').val();
    if (typeof name !== 'undefined' && name != "") {
        filter.name = name;
    }
    var minPrice = $('#MinPrice').val();
    if (typeof minPrice !== 'undefined' && minPrice != "") {
        filter.minPrice = minPrice;
    }
    var maxPrice = $('#MaxPrice').val();
    if (typeof maxPrice !== 'undefined' && maxPrice != "") {
        filter.maxPrice = maxPrice;
    }
    var fieldOfStudyId = $('#FieldOfStudyId').val();
    if (typeof fieldOfStudyId !== 'undefined' && fieldOfStudyId != "") {
        filter.fieldOfStudyId = fieldOfStudyId;
    }

    $.ajax({
        type: "GET",
        url: '/Projects/Filter',
        data: filter,
        success: function (data) {
            $('#Projects').empty(divs);
            for (i in data) {
                var item = data[i];
                var nameHtml = `<h3>${item.name}</h3>`;
                var descHtml = `<p>${item.description}</p>`;
                var rankHtml = `<h6>${item.rank} / 5</h6>`;
                var avgHtml = `<h6>${item.avgGrade}</h6>`;
                var detailsLink = `<a href="/Projects/Details/${item.id}" class="btn-card">פרטים</a>`;
                var buyLink = `<a href="/Sales/Buy/${item.id}" class="btn-card">קנה</a>`;
                var divs = `<div class="col-md-4"> <div class="card-content"> <div class="card-desc"> ${nameHtml} ${descHtml} ${rankHtml} ${avgHtml} ${detailsLink} ${buyLink} </div></div></div>`;
                $('#Projects').append(divs);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
        }
    });
}

$(document).ready(function () {
    $("#project-filter").click(filterProjects);
    filterProjects();
}
);