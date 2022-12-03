pipeline {
    agent any

    stages {
        stage('Check dotnet') {
	    steps {
	        sh 'dotnet --version'
	    }
	}
	stage('Build server') {
            steps {
	        sh '''
		    cd ./Server/PL.Web
		    dotnet restore
		    dotnet build -c Release -o "../../build/Server" --no-restore
		'''
	    }
	}
    }
}
