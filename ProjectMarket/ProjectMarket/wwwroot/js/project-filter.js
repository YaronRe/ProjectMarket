function filterProjects() {
    let filter = {};
    let name = $('#Name').val();
    if (typeof name !== 'undefined' && name != "") {
        filter.name = name;
    }
    let minPrice = $('#MinPrice').val();
    if (typeof minPrice !== "undefined" && minPrice !== "") {
        filter.minPrice = minPrice;
    }
    let maxPrice = $('#MaxPrice').val();
    if (typeof maxPrice !== "undefined" && maxPrice !== "") {
        filter.maxPrice = maxPrice;
    }

    const fieldOfStudyId = $('#FieldOfStudyId').val();
    if (typeof fieldOfStudyId !== "undefined" && fieldOfStudyId != "") {
        filter.fieldOfStudyId = fieldOfStudyId;
    }

    const userId = $("#UserId").val();
    if (userId !== "undefined" && !isNaN(parseInt(userId))) {
        filter.userId = userId;
    }

    $.ajax({
        type: "GET",
        url: "/Projects/Filter",
        data: filter,
        success: function (data) {
            $("#Projects").empty();
            for (i in data) {
                let item = data[i];
                let nameHtml = `<h3>${item.name}</h3>`;
                let descHtml = `<p>${item.description}</p>`;
                let detailsLink = `<a href="/Projects/Details/${item.id}" class="btn">פרטים</a>`;
                let buyLink = `<a href="/Sales/Buy/${item.id}" class="btn">קנה</a>`;
                let grade = "";
                if (item.avgGrade == null) {
                    grade = `<div class="col-xs-1">
                                <i class="far fa-star null-icon" title="עוד לא הוזן דירוג'"></i>
                             </div>
                             <div class="col-xs-1">
                                <i class="far fa-file null-icon" title="לא הוזנו ציונים"></i>
                             </div>`
                } else {
                    grade = `<div class="col-xs-1">
                                 <i class="far fa-star" title="דירוג (מתוך חמש)">${item.rank}</i>
                             </div>                     
                             
                             <div class="col-xs-1">
                                 <i class="far fa-file" title="ציון מומצע">${item.avgGrade}</i>
                             </div>`
                }
                
                let divs = `
                            <div class="col-md-4"> 
                                <div class="card-content"> 
                                    <div class="card-desc">
                                        <div class="row">
                                            <div class="col-xs-9">
                                                <h3>${nameHtml}</h3>
                                            </div>
                                            ${grade}
                                    </div>
                                    <div class="card-body">
                                        ${descHtml}
                                    </div>
                                    <div class="row modal-btn">
                                        ${detailsLink}
                                        ${buyLink}
                                    </div>
                                </div>
                            </div>`;
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