{ lib
, buildDotnetModule
, dotnetCorePackages

}:
buildDotnetModule rec {
  pname = "space-station-14";
  version = "0.1";

  src = ./.;
  buildType = "DebugOpt";
  selfContainedBuild = false;

  projectFile = "SpaceStation14.sln";

  # derivation args get passed as env vars eventually
  DOTNET_gcServer = "1";

  # Auto-generated, but for CI, we run it blind with `nix-build -A package.passthru.fetch-deps` first
  # so this gets created and its not in repo normally
  nugetDeps = ./deps.nix;

  testProjectFile = "Content.Tests/Content.Tests.csproj";
  dotnetTestFlags = [
    "--logger \"html\""
  ];
  doCheck = true;

  dotnet-sdk = dotnetCorePackages.sdk_7_0;
  dotnet-runtime = dotnetCorePackages.runtime_7_0;

  dotnetFlags = [
    "-nologo"
  ];

  runtimeDeps = [
    # Required by the game.
    glfw
    SDL2
    glibc
    libGL
    openal
    freetype
    fluidsynth

    # Needed for file dialogs.
    gtk3
    pango
    cairo
    atk
    zlib
    glib
    gdk-pixbuf

    # Avalonia UI dependencies.
    libX11
    libICE
    libSM
    libXi
    libXcursor
    libXext
    libXrandr
    fontconfig
    glew

    # TODO: Figure out dependencies for CEF support.
  ];

  executables = [];
}
