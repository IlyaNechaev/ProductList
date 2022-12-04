pipeline {
    agent any

    environment {
        CURRENT_PATH = sh(script: "pwd", returnStdout: true).trim()
        PATH_DOCKER_IMAGES = "/root/eshop/images"
    }

    stages {
        stage('Check docker') {
            steps {
	        sh "docker --version"
	    }
        }
        // SERVER
        stage('Build server image') {
            steps {
                sh '''
		    docker build -t pl_server ./Server
		    docker container prune -f
		    docker image prune -f
		'''
            }
        }
        stage('Save server image') {
            steps {
                sh "docker save -o ${env.PATH_DOCKER_IMAGES}/pl_server.tar pl_server"
            }
        }
        // CLIENT
        stage('Build client image') {
            steps {
                sh '''
                    docker build -t pl_client ./Client/react-app
		    docker container prune -f
		    docker image prune -f
                '''
            }
        }
        stage('Save client image') {
            steps {
                sh "docker save -o ${env.PATH_DOCKER_IMAGES}/pl_client.tar pl_client"
            }
        }
    }
}
