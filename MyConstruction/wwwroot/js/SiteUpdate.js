


function AddTeam(url) {
    var placeHolderElement = $("#ModalPlaceHolder");

    $.get(url).done(function (data) {
        placeHolderElement.html(data);
        placeHolderElement.find('.modal').modal('show');

        

        $('#workCategoryList').change(function () {
            var selectedCategoryId = $(this).val();
            var contractorsList = $('#ContractorsList');
            var projectId = $('#projectId').val();

            $.get(`/Supervisor/Projects/Team/GetContractors?projectId=${projectId}&workCategoryId=${selectedCategoryId}`).done(function (contractors) {

                contractorsList.empty();

                $.each(contractors, function (index, contractor) {
                    contractorsList.append($('<option>', {
                        value: contractor.id,
                        text: contractor.name
                    }));
                });
            });
        });
    });

    placeHolderElement.on('click', '[data-save="modal"]', function (event) {

        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (data) {

            placeHolderElement.find('.modal').modal('hide');

        });

    });




    placeHolderElement.on('click', '[data-dismiss="modal"]', function (event) {

        placeHolderElement.find('.modal').modal('hide');

    })


}


function TeamDelete(url) {

    var placeHolderElement = $("#ModalPlaceHolder");

    $.get(url).done(function (data) {

        placeHolderElement.html(data);
        placeHolderElement.find('.modal').modal('show');

    })


    placeHolderElement.on('click', '[data-dismiss="modal"]', function (event) {

        placeHolderElement.find('.modal').modal('hide');

    })

}


function TeamEdit(url) {

    var placeHolderElement = $("#ModalPlaceHolder");

    $.get(url).done(function (data) {

        placeHolderElement.html(data);
        placeHolderElement.find('.modal').modal('show');

    })


    placeHolderElement.on('click', '[data-dismiss="modal"]', function (event) {

        placeHolderElement.find('.modal').modal('hide');

    })

}


function AddMaterial(url) {

    var placeHolderElement = $("#MaterialPopup");

    $.get(url).done(function (data) {

        placeHolderElement.html(data);
        placeHolderElement.find('.modal').modal('show');

    });



    placeHolderElement.on('click', '[data-dismiss="modal"]', function (event) {

        placeHolderElement.find('.modal').modal('hide');

    });

}


function EditMaterial(url) {

    var placeHolderElement = $("#MaterialPopup");

    $.get(url).done(function (data) {

        placeHolderElement.html(data);
        placeHolderElement.find('.modal').modal('show');

    });

    placeHolderElement.on('click', '[data-dismiss="modal"]', function (event) {

        placeHolderElement.find('.modal').modal('hide');

    });


}



function DeleteMaterial(url) {

    var placeHolderElement = $("#MaterialPopup");

    $.get(url).done(function (data) {

        placeHolderElement.html(data);
        placeHolderElement.find('.modal').modal('show');

    });

    placeHolderElement.on('click', '[data-dismiss="modal"]', function (event) {

        placeHolderElement.find('.modal').modal('hide');

    });


}


function AddQuality(url) {

    var placeHolderElement = $('#QualityPopup');

    $.get(url).done(function (data) {
        placeHolderElement.html(data);
        placeHolderElement.find('.modal').modal('show');

        $('#WorkCategoryList').change(function () {
            var selectedCategoryId = $(this).val();
            var tasklist = $('#TaskList');
            var projectId = $('#projectId').val();

            $.get(`/Supervisor/Quality/GetTasks?projectId=${projectId}&workCategoryId=${selectedCategoryId}`).done(function (tasks) {

                tasklist.empty();

                $.each(tasks, function (index, task) {
                    tasklist.append($('<option>', {
                        value: task.taskId,
                        text: task.taskName
                    }));
                });
            });
        });
    });

    placeHolderElement.on('click', '[data-dismiss="modal"]', function (event) {

        placeHolderElement.find('.modal').modal('hide');

    });


}



function QualityEdit(url) {

    var placeHolderElement = $('#QualityPopup');

    $.get(url).done(function (data) {

        placeHolderElement.html(data);
        placeHolderElement.find('.modal').modal('show');

    });

    placeHolderElement.on('click', '[data-dismiss="modal"]', function (event) {

        placeHolderElement.find('.modal').modal('hide');

    });


}



function QualityDelete(url) {

    var placeHolderElement = $('#QualityPopup');

    $.get(url).done(function (data) {

        placeHolderElement.html(data);
        placeHolderElement.find('.modal').modal('show');

    });

    placeHolderElement.on('click', '[data-dismiss="modal"]', function (event) {

        placeHolderElement.find('.modal').modal('hide');

    });



}



function TaskReadMore(url) {

    var placeHolderElement = $('#QualityPopup');

    $.get(url).done(function (data) {

        placeHolderElement.html(data);
        placeHolderElement.find('.modal').modal('show');

    });

    placeHolderElement.on('click', '[data-dismiss="modal"]', function (event) {

        placeHolderElement.find('.modal').modal('hide');

    });


}


function UpdateStatus(url) {

    var placeHolderElement = $('#QualityPopup');

    $.get(url).done(function (data) {

        placeHolderElement.html(data);
        placeHolderElement.find('.modal').modal('show');

    });

    placeHolderElement.on('click', '[data-dismiss="modal"]', function (event) {

        placeHolderElement.find('.modal').modal('hide');

    });

}


$(document).ready(function () {
    $('.badge').each(function () {
        var text = $(this).text().trim();
        if (text === 'Pending' || text === 'InProgress') {
            $(this).css('background-color', '#777');
        } else if (text === 'Done') {
            $(this).css('background-color', '#198754');
        }
    });
});