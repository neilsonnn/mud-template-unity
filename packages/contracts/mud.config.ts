import { mudConfig, resolveTableId } from "@latticexyz/world/register";

export default mudConfig({
  overrideSystems: {
    IncrementSystem: {
      name: "increment",
      openAccess: true,
    },
  },

  enums: {
    TerrainType: ["None", "Rock", "Mine", "Tree", "Player"],
  },

  tables: {
    Counter: {
      schema: {
        value: "uint32",
      },
      storeArgument: true,
    },
    
    TypeTest: "TerrainType",
  },
  modules: [
    {
      name: "KeysWithValueModule",
      root: true,
      args: [resolveTableId("Counter")],
    },
  ],
});
