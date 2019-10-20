echo "Preparing UI build"
cd ./numpuk-ui
npm run build
cd ..

echo "Copying built files to server project"
cp -a ./numpuk-ui/build/. ./Numpuk2/Numpuk2/wwwroot/

echo "Deleting UI build directory"
rm -rf ./numpuk-ui/build/

echo "Make server build"
cd ./Numpuk2
dotnet publish -c Release

echo "Deleting wwwroot"
rm -rf ./Numpuk2/wwwroot/

echo "Reseting repository"
cd ./../
git reset --hard

echo "Copy build"
cp -a ./Numpuk2/Numpuk2/bin/Release/netcoreapp3.0/publish/. ./build/

echo "Deleting source build"
rm -rf ./Numpuk2/Numpuk2/bin/

sleep 30s