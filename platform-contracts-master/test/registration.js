var LendeltaPlatform = artifacts.require("./LendeltaPlatform.sol");

contract("LendeltaPlatform", function (accounts) {
    var account = accounts[0];
    var account1 = accounts[1];

    var platform;

    before('setup', (done) => {
        LendeltaPlatform.deployed().then((_platform) => {
            platform = _platform;
            return platform.setLendeltaManager(account);
        })
        .then(() => {
            done();
        });
    });

    it("should register broker", () => {
        return platform.registerBroker("test", account1)
            .then(() => {
                return platform.getBrokerAddress.call("test");
            })
            .then((broker) => {
                assert.equal(account1, broker.valueOf(), "Broker should exist");
            });
    });

    it("should register manager", () => {
        return platform.registerManager("testManager", "test", 10, 10)
            .then(() => {
                return platform.getManager.call(0);
            })
            .then((m) => {
                assert.equal("testManager", m[0], "Manager's name is testManager");
                assert.equal(1, m[1], "Manager's level is 1");
                assert.equal(1000, m[2], "Manager's free coins amount is 1000");
            });
    });
});
