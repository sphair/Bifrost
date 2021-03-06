﻿describe("when handling a single command", function () {

    Bifrost.namespace("Bifrost.commands.CommandDescriptor");
    Bifrost.commands.CommandDescriptor.createFrom = function () {
    };

    var descriptorSpy = sinon.spy(Bifrost.commands.CommandDescriptor, "createFrom"),
        commandCoordinator = Bifrost.commands.commandCoordinator,
        ajaxSpy = sinon.spy(jQuery, "ajax"),
        command = { command: {} },
        options = { someOptions: {} };

    beforeEach(function () {
        (function becauseOf() {
            commandCoordinator.handle(command, options);
        })();
    });

    it("should create methodParameters to be sent to the server", function () {
        expect(descriptorSpy.calledOnce).toBeTruthy();
        expect(descriptorSpy.calledWith(command)).toBeTruthy();
    });

    it("should post the command to the server with the default handleUrl", function () {
        var handleUrl = ajaxSpy.getCall(0).args[0].url;
        expect(handleUrl).toEqual("/CommandCoordinator/Handle");
    });

    afterEach(function () {
        ajaxSpy.restore();
    });

});