{
  description = "Development environment for Space Station 14";

  inputs.nixpkgs.url = "github:NixOS/nixpkgs/release-23.05";
  inputs.flake-utils.url = "github:numtide/flake-utils";

  outputs = { self, nixpkgs, flake-utils }:
    flake-utils.lib.eachDefaultSystem (system: let
      legacy-pkgs = nixpkgs.legacyPackages.${system};
      pkgs = import nixpkgs { inherit system; };
      test-ci = pkgs.callPackage ./ci-check.nix { };
    in {
      devShells.default = import ./shell.nix { pkgs = legacy-pkgs; };
      checks = { inherit test-ci; };
    });
}
