const LendeltaPlatform = artifacts.require("./LendeltaPlatform.sol");

module.exports = function(deployer, network, accounts) {
    deployer.deploy(LendeltaPlatform);
};

