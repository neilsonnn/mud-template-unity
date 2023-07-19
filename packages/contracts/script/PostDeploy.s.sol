// SPDX-License-Identifier: MIT
pragma solidity >=0.8.0;

import { Script } from "forge-std/Script.sol";
import { IWorld } from "../src/codegen/world/IWorld.sol";
import { TypeTest } from "../src/codegen/Tables.sol";
import { TerrainType } from "../src/codegen/Types.sol";

contract PostDeploy is Script {
  function run(address worldAddress) external {
    // Load the private key from the `PRIVATE_KEY` environment variable (in .env)
    uint256 deployerPrivateKey = vm.envUint("PRIVATE_KEY");

    // Start broadcasting transactions from the deployer account
    vm.startBroadcast(deployerPrivateKey);

    // ------------------ EXAMPLES ------------------

    // Call increment on the world via the registered function selector
    // uint32 newValue = IWorld(worldAddress).increment();
    // console.log("Increment via IWorld:", newValue);

    // TypeTest.set(keccak256(abi.encode("test")), TerrainType.Rock);

    vm.stopBroadcast();
  }
}
