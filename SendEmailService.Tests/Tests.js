/// <reference path="scripts/dojo/dojo.js" />
/// <reference path="scripts/jasmine.js" />

require(["dojo/request"], function(request) {   
    describe("CanSendEmailWithPost", function () {
        it("can post parameters", function () {
            var data, parameters = JSON.stringify(
                {
                        Email: {
                            ToIds: [1, 2],
                            FromId: 1,
                        },
                        Template: {
                            TemplateId: 1,
                            TemplateValues: {
                                "url": "http://utah.gov",
                                "name": "Scott Davis",
                                "address": "123 south man street",
                                "phone": "19001231100",
                                "email": "input@email.com"
                            }
                        }
                    
                });
            
            runs(function () {
                request.post("http://localhost/SendEmailService/Notify",
                     {
                         //CORS does not allow this to be set so the test fails
                         headers: {
                             "Content-Type": "application/json"
                         },
                         data: parameters,
                         handleAs: "json"
                     }).then(function (dataIn) {
                         data = dataIn;
                         console.log('success');
                     }, function (err) {
                         data = err;
                         console.log('error function');
                         console.dir(err);
                     });
            });

            waitsFor(function () {
                return data;
            });

            runs(function () {
                console.dir(data);
                expect(data).toBeDefined();
                expect(data.status).toEqual(200);
            });
        });
    });
});