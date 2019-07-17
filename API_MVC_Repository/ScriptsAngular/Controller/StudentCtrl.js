

app.controller('StudentCtrl', ['$scope', 'CrudService',
    function ($scope, CrudService) {
        debugger;
        // Base Url 
        var baseUrl = '/api/Student/';
       
        $scope.studentID = 0;
        $scope.SaveUpdate = function () {
            //debugger;
            var student = {
               
                FirstName: $scope.firstName,
                LastName: $scope.lastName,
                Email: $scope.email,
                Address: $scope.address,
                StudentID: $scope.studentID
            }
            var Action = document.getElementById("btnSubmit").getAttribute("value");
            if (Action == "Submit") {
                var apiRoute = baseUrl + 'SaveStudent/';
                var saveStudent = CrudService.post(apiRoute, student);
                saveStudent.then(function (response) {
                    if (response.data != "") {
                        alert("Data Save Successfully");
                        $scope.GetStudents();
                        $scope.Clear();

                    } else {
                        alert("Some error");
                    }

                }, function (error) {
                    console.log("Error: " + error);
                });
            }
            else {
                debugger;
                var apiRoute = baseUrl + 'UpdateStudent/';
                var UpdateStudent = CrudService.put(apiRoute, student);
                UpdateStudent.then(function (response) {
                    if (response.data != "") {
                        alert("Data Update Successfully");
                        $scope.GetStudents();
                        $scope.Clear();
                        document.getElementById("btnSubmit").setAttribute("value", "Submit");
                        document.getElementById("btnSubmit").style.backgroundColor = "cornflowerblue";
                        document.getElementById("spn").innerHTML = "Add New Student";
                    } else {
                        alert("Some error");
                    }

                }, function (error) {
                    console.log("Error: " + error);
                });
            }
        }


        $scope.GetStudents = function () {
            debugger;
            var apiRoute = baseUrl + 'GetStudents';
            var student = CrudService.getAll(apiRoute);
            student.then(function (response) {
                
                $scope.students = response.data;

            },
            function (error) {
                console.log("Error: " + error);
            });


        }

        $scope.GetStudentByID = function (dataModel) {
            debugger;
            //var apiRoute = baseUrl + 'GetStudentByID';
            var apiRoute = baseUrl + 'GetStudentByID/' + dataModel.StudentID;
            var student = CrudService.getbyID(apiRoute);
            student.then(function (response) {
                $scope.studentID = response.data.StudentID;
                $scope.firstName = response.data.FirstName;
                $scope.lastName = response.data.LastName;
                $scope.email = response.data.Email;
                $scope.address = response.data.Address;
                document.getElementById("btnSubmit").setAttribute("value", "Update");
                document.getElementById("btnSubmit").style.backgroundColor = "Green";
                document.getElementById("spn").innerHTML = "Update Student Information";
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.DeleteStudent = function (dataModel) {
            debugger;
            var isconf = confirm('You are about to delete ' + dataModel.FirstName + ' ' + dataModel.LastName + ' .Are you sure?');
            if (isconf)
            {
                var apiRoute = baseUrl + 'DeleteStudent/' + dataModel.StudentID;
                var deleteStudent = CrudService.delete(apiRoute);
                deleteStudent.then(function (response) {
                    if (response.data != "") {
                        alert("Data Delete Successfully");
                        $scope.GetStudents();
                        $scope.Clear();

                    } else {
                        alert("Some error");
                    }

                }, function (error) {
                    console.log("Error: " + error);
                });
            }
            
        }

        $scope.Clear = function () {
            $scope.studentID = 0;
            $scope.firstName = "";
            $scope.lastName = "";
            $scope.email = "";
            $scope.address = "";
            
        }

    }]);