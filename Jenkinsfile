pipeline {
  agent any
  stages {
    stage('build') {
      agent {
        node {
          label 'build'
        }

      }
      steps {
        powershell(script: './build.ps1', returnStatus: true)
      }
    }
  }
}