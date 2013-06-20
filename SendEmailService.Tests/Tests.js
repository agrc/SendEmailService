/// <reference path="scripts/jasmine.js" />
/// <reference path="scripts/dojo/dojo.js" />

describe("Sanity", function () {
    it("can post parameters", function () {
        console.log("requiring");
        require(["dojo/request"], function (request) {
            console.log("requesting");
            request("http://localhost/SendEmailService/Notify",
                {
                    data: {
                        id: "123"
                    },
                    method: "POST"
                }).then(function (data) {
                    console.log(data);
                    // do something with handled data
                    expect(data).toEqual("123");
                }, function(err) {
                    // handle an error condition
                    console.log(data);
                }, function(evt) {
                    // handle a progress event
                });
        });
    });
});