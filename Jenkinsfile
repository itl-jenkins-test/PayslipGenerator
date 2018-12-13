pipeline {
  agent any
  stages {
    stage('error') {
      agent {
        node {
          label 'build'
        }

      }
      steps {
        powershell 'build.ps1'
      }
    }
  }
}