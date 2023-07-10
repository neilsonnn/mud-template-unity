// SPDX-License-Identifier: MIT
pragma solidity >=0.8.0;
import { System } from "@latticexyz/world/src/System.sol";
import { IStore } from "@latticexyz/store/src/IStore.sol";
import { TypeTest } from "../codegen/Tables.sol";
import { TerrainType } from "../codegen/Types.sol";

contract TypeTestSystem is System {
  function createNewType() public {
    TypeTest.set(keccak256(abi.encode("test")), TerrainType.Rock);
  }

}
