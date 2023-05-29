// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function DrawPoints() {
    $.ajax({
        type: 'GET',
        url: '/PointRepository/GetPoints',
        dataType: 'json',
        success: function (data) {
            var width = window.innerWidth;
            var height = window.innerHeight;
            var container = new Konva.Stage({
                container: 'pointContainer',
                width: width,
                height: height
            });
            var layer = new Konva.Layer();
            for (var i = 0; i < data.length; i++) {
                // drawing each point
                var group = new Konva.Group();
                var point = new Konva.Circle({
                    x: data[i].x,
                    y: data[i].y,
                    radius: data[i].r,
                    fill: data[i].color,
                    name: data[i].pointID + ''
                });
                point.on('dblclick', function (e) {
                    var id = e.currentTarget.attrs.name;
                    $.ajax({
                        type: 'POST',
                        url: '/PointRepository/RemovePoint',
                        dataType: 'text',
                        data: { pointid: id },
                        success: function (response) {
                            if (response) {
                                var shapes = container.find('.' + id);
                                for (var i = 0; i < shapes.length; i++) {
                                    shapes[i].destroy();
                                }
                                layer.draw();
                            } else { alert("Error") }
                        }
                    });
                });
                group.add(point);
                var currentPosition = data[i].y + data[i].r + 5;
                for (var j = 0; j < data[i].comments.length; j++) {
                    // draw comments
                    var str = data[i].comments[j].commentText;
                    var comment = new Konva.Label({
                        x: data[i].x,
                        offsetX: (data[i].comments[j].commentText.length * 7.188) / 2 + 5,
                        y: currentPosition,
                        opacity: 1,
                    });

                    comment.add(
                        new Konva.Tag({
                            fill: data[i].comments[j].backgroundColor,
                            stroke: "Grey",
                            name: data[i].pointID+ ''
                        })
                    );

                    comment.add(
                        new Konva.Text({
                            text: data[i].comments[j].commentText,
                            fontFamily: 'Calibri',
                            fontSize: 14,
                            padding: 5,
                            fill: 'Green',
                            name: data[i].pointID + ''
                        })
                    );
                    group.add(comment)
                    currentPosition += 28;
                }
                layer.add(group);
            }
            container.add(layer);
        },
        error: function (ex) {
            alert("     !!! Error !!!\n ExceptionType: " + ex.ExceptionType);
        }
    });
}
